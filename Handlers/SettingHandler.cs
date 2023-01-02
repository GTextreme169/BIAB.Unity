using System.Collections.Generic;
using System.IO;
using BIAB.Unity.Other;
using UnityEngine;

namespace BIAB.Unity.Handlers
{
    public class SettingHandler
    {
        
        private static Dictionary<string, string> values = new Dictionary<string, string>();
        
        public static void Load(string[] additional)
        {
            if (additional == null)
                return;
            
            for (int i = 0; i < additional.Length; i++) 
                values.Add(additional[i].Split(':')[0],additional[i].Split(':')[1]);
        }

        public static void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath) == false)
            {
                Debug.LogWarningFormat("No File Found at Path: {0}", filePath);
                return;
            }
            string[] lines = File.ReadAllLines(filePath);
            Load(lines);
        }

        public static void Save(string filePath)
        {
            List<string> tempValues = new List<string>();
            foreach (KeyValuePair<string, string> entry in values)
            {
                tempValues.Add(entry.Key + ":" + entry.Value);
            }
            if(File.Exists(filePath))
                File.Move(filePath, filePath+"-temp");
            try
            {
                File.WriteAllLines(filePath, tempValues.ToArray());
                File.Delete(filePath+"-temp");
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
                if(File.Exists(filePath))
                    File.Delete(filePath);
                File.Move(filePath+"-temp", filePath);
            }
            
        }

        public static int GetInt(string Name, int Default)
        {
            if (values.ContainsKey(Name))
            {
                return int.Parse(values[Name]);
            }
            return ExtendedPrefs.GetInt(Name, Default);
        }
        public static void SetInt(string Name, int Default)
        {
            if (values.ContainsKey(Name))
            {
                values[Name] = Default.ToString();
            }
            else
            {
                values.Add(Name, Default.ToString());
            }
        }
        public static string GetString(string Name, string Default)
        {
            if (values.ContainsKey(Name))
            {
                return (string)values[Name];
            }
            return ExtendedPrefs.GetString(Name, Default);
        }
        public static void SetString(string Name, string Default)
        {
            if (values.ContainsKey(Name))
            {
                values[Name] = Default;
            }
            else
            {
                values.Add(Name, Default);
            }
        }
        public static float GetFloat(string Name, float Default)
        {
            if (values.ContainsKey(Name))
            {
                return float.Parse(values[Name]);
            }
            return ExtendedPrefs.GetFloat(Name, Default);
        }
        public static void SetFloat(string Name, float Default)
        {
            if (values.ContainsKey(Name))
            {
                values[Name] = Default.ToString();
            }
            else
            {
                values.Add(Name, Default.ToString());
            }
        }
        /*public static Vector3 GetVector3(string Name, Vector3 Default)
        {
            if(values.ContainsKey(Name))
            {
                return (Vector3)values[Name];
            }
            return ExtendedPrefs.GetVector3(Name, Default);
        }
        public static void SetVector3(string Name, Vector3 Default)
        {
            if(values.ContainsKey(Name))
            {
                values[Name] = Default;
            }
            else
            {
                values.Add(Name, Default);
            }
        }*/
    }
}