using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using BIAB.Unity.Interfaces;
using UnityEngine;

namespace BIAB.Unity.Handlers
{
    public static class FileHandler
    {
        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            if (append == false)
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        /// <summary>
        /// Reads an object instance from a binary file.
        /// </summary>
        /// <typeparam name="T">The type of object to read from the binary file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the binary file.</returns>
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
        public delegate void FileCallbackHandler<T>(T data);
        #region FileLocking
        private static List<string> InUsePaths;
        private static void PathSetup()
        {
            if (InUsePaths == null) InUsePaths = new List<string>();
        }
        #endregion

        #region Direct
        #region Bytes
        [System.Obsolete("Upgrade to Async Functions")]
        public static T ReadFileByte<T>(string Path) where T : IByteSerializable, new()
        {
            if (File.Exists(Path) == false)
                return default;
            byte[] bytes = File.ReadAllBytes(Path);
            T t = new T();
            t.FromBytes(bytes);
            return t;
        }
        [System.Obsolete("Upgrade to Async Functions")]
        public static bool WriteFileByte<T>(string Path, T data) where T : IByteSerializable
        {
            PathSetup();
            InUsePaths.Add(Path); // Lock File
            bool worked = false;
            try
            {
                byte[] bytes = data.ToBytes();
                File.WriteAllBytes(Path, bytes);
                byte[] test = File.ReadAllBytes(Path);
                worked = (bytes == test);
            }
            catch (System.Exception e)
            {
                ConsoleHandler.LogError(e);
            }
            InUsePaths.Remove(Path);    // Unlock File 
            return worked;
        }
        #endregion
        #region JSON
        [System.Obsolete("Upgrade to Async Functions")]
        public static T ReadFileJSON<T>(string Path) where T : IJsonSerializable, new()
        {
            if (File.Exists(Path) == false)
                return default;
            string[] lines = File.ReadAllLines(Path);
            T t = new T();
            t.FromJSON(lines);
            return t;
        }
        [System.Obsolete("Upgrade to Async Functions")]
        public static bool WriteFileJSON<T>(string Path, T data) where T : IJsonSerializable
        {
            PathSetup();
            InUsePaths.Add(Path); // Lock File
            bool worked = false;
            try
            {
                string[] lines = data.ToJSON();
                File.WriteAllLines(Path, lines);
                string[] test = File.ReadAllLines(Path);
                worked = (lines == test);
            }
            catch (System.Exception e)
            {
                ConsoleHandler.LogError(e);
            }
            InUsePaths.Remove(Path); // Unlock File
            return worked;
        }
        #endregion
        #endregion
        #region Async
        #region Bytes
        public static async void ReadFileByteAsync<T>(string Path, FileCallbackHandler<T> callback) where T : IByteSerializable, new()
        {
            if (File.Exists(Path) == false)
                callback(default);
            PathSetup();
            while (InUsePaths.Contains(Path))
                await Task.Yield();
            InUsePaths.Add(Path); // Lock File
            byte[] bytes = File.ReadAllBytes(Path);
            T t = new T();
            t.FromBytes(bytes);
            await Task.Yield();
            InUsePaths.Remove(Path); // Unlock File
            callback(t);
        }
        public static async void WriteFileByteAsync<T>(string Path, T data) where T : IByteSerializable
        {
            PathSetup();
            while (InUsePaths.Contains(Path))
                await Task.Yield();
            InUsePaths.Add(Path); // Lock File
            try
            {
                byte[] bytes = data.ToBytes();
                File.WriteAllBytes(Path, bytes);
            }
            catch (System.Exception e)
            {
                ConsoleHandler.LogError(e);
            }
            await Task.Yield();
            InUsePaths.Remove(Path); // Unlock File
        }
        #endregion
        #region JSON
        public static async void ReadFileJSONAsync<T>(string Path, FileCallbackHandler<T> callback) where T : IJsonSerializable, new()
        {
            if (File.Exists(Path) == false)
                callback(default);
            PathSetup();
            while (InUsePaths.Contains(Path))
                await Task.Yield();
            InUsePaths.Add(Path); // Lock File
            string[] lines = File.ReadAllLines(Path);
            T t = new T();
            t.FromJSON(lines);
            await Task.Yield();
            InUsePaths.Remove(Path); // Unlock File
            callback(t);
        }
        public static async void WriteFileJSONAsync<T>(string Path, T data) where T : IJsonSerializable
        {
            PathSetup();
            while (InUsePaths.Contains(Path))
                await Task.Yield();
            InUsePaths.Add(Path); // Lock File
            try
            {
                string[] lines = data.ToJSON();
                File.WriteAllLines(Path, lines);
            }
            catch (System.Exception e)
            {
                ConsoleHandler.LogError(e);
            }
            await Task.Yield();
            InUsePaths.Remove(Path); // Unlock File
        }
        #endregion
        #endregion


        public static Texture2D LoadTexture2D(string path)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            Texture2D temp = new Texture2D(1, 1);
            temp.LoadImage(bytes);
            return temp;
        }

        public static bool SaveTexture2D(string path, Texture2D texture)
        {
            if (texture == null)
            {
                Debug.LogError("Null Texture Provided!\nPath: " + path);
                return false;
            }
            try
            {
                byte[] bytes = texture.EncodeToPNG();
                System.IO.File.WriteAllBytes(path, bytes);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
                return false;
            }

            return true;
        }

        public static T Deserialize<T>(byte[] param)
        {
            using (MemoryStream ms = new MemoryStream(param))
            {
                IFormatter br = new BinaryFormatter();
                return (T)br.Deserialize(ms);
            }
        }
        public static byte[] Serialize<T>(T param)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter br = new BinaryFormatter();
                br.Serialize(ms, param);
                return ms.ToArray();
            }
        }
    }

}