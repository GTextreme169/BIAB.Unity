/* Made By: Trevin Pointer
 * Description: Extends the PlayerPrefs To Several Other Non-Primitive DataTypes
 * Uses: Adds Set/Get/Delete Functions For String,Int,Float,Bool,Vector2,Vector3,Vector4,Quaternion,Enum,SerializedObject,Color
 * Install: Place script anywhere in Asset Folder
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BIAB
{
    public static class ExtendedPrefs
    {
        public static void SetString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }
        public static string GetString(string key, string defaultValue = "")
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }
        public static void DeleteString(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }

        public static void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }
        public static int GetInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }
        public static void DeleteInt(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }

        public static void SetFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
        }
        public static float GetFloat(string key, float defaultValue = 0)
        {
            return PlayerPrefs.GetFloat(key, defaultValue);
        }
        public static void DeleteFloat(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }

        public static void SetBool(string key, bool value)
        {
            PlayerPrefs.SetInt("(bool)" + key, (value) ? 1 : 0);
        }
        public static bool GetBool(string key, bool defaultValue = false)
        {
            return (PlayerPrefs.GetInt("(bool)" + key, (defaultValue) ? 1 : 0) == 1);
        }
        public static void DeleteBool(string key)
        {
            PlayerPrefs.DeleteKey("(bool)" + key);
        }

        public static void SetVector2(string key, Vector2 value)
        {
            PlayerPrefs.SetFloat("(V2)" + key + "(x)", value.x);
            PlayerPrefs.SetFloat("(V2)" + key + "(y)", value.y);
        }
        public static Vector2 GetVector2(string key, Vector2 defaultValue = new Vector2())
        {
            return new Vector2(
                PlayerPrefs.GetFloat("(V2)" + key + "(x)", defaultValue.x),
                PlayerPrefs.GetFloat("(V2)" + key + "(y)", defaultValue.y)
                );
        }
        public static void DeleteVector2(string key)
        {
            PlayerPrefs.DeleteKey("(V2)" + key + "(x)");
            PlayerPrefs.DeleteKey("(V2)" + key + "(y)");
        }

        public static void SetVector3(string key, Vector3 value)
        {
            PlayerPrefs.SetFloat("(V3)" + key + "(x)", value.x);
            PlayerPrefs.SetFloat("(V3)" + key + "(y)", value.y);
            PlayerPrefs.SetFloat("(V3)" + key + "(z)", value.z);
        }
        public static Vector3 GetVector3(string key, Vector3 defaultValue = new Vector3())
        {
            return new Vector3(
                PlayerPrefs.GetFloat("(V3)" + key + "(x)", defaultValue.x),
                PlayerPrefs.GetFloat("(V3)" + key + "(y)", defaultValue.y),
                PlayerPrefs.GetFloat("(V3)" + key + "(z)", defaultValue.z)
                );
        }
        public static void DeleteVector3(string key)
        {
            PlayerPrefs.DeleteKey("(V3)" + key + "(x)");
            PlayerPrefs.DeleteKey("(V3)" + key + "(y)");
            PlayerPrefs.DeleteKey("(V3)" + key + "(z)");
        }

        public static void SetVector4(string key, Vector4 value)
        {
            PlayerPrefs.SetFloat("(V4)" + key + "(x)", value.x);
            PlayerPrefs.SetFloat("(V4)" + key + "(y)", value.y);
            PlayerPrefs.SetFloat("(V4)" + key + "(z)", value.z);
            PlayerPrefs.SetFloat("(V4)" + key + "(w)", value.w);
        }
        public static Vector4 GetVector4(string key, Vector4 defaultValue = new Vector4())
        {
            return new Vector4(
                PlayerPrefs.GetFloat("(V4)" + key + "(x)", defaultValue.x),
                PlayerPrefs.GetFloat("(V4)" + key + "(y)", defaultValue.y),
                PlayerPrefs.GetFloat("(V4)" + key + "(z)", defaultValue.z),
                PlayerPrefs.GetFloat("(V4)" + key + "(w)", defaultValue.w)
                );
        }
        public static void DeleteVector4(string key)
        {
            PlayerPrefs.DeleteKey("(V4)" + key + "(x)");
            PlayerPrefs.DeleteKey("(V4)" + key + "(y)");
            PlayerPrefs.DeleteKey("(V4)" + key + "(z)");
            PlayerPrefs.DeleteKey("(V4)" + key + "(w)");
        }

        public static void SetQuaternion(string key, Quaternion value)
        {
            PlayerPrefs.SetFloat("(Q)" + key + "(x)", value.x);
            PlayerPrefs.SetFloat("(Q)" + key + "(y)", value.y);
            PlayerPrefs.SetFloat("(Q)" + key + "(z)", value.z);
            PlayerPrefs.SetFloat("(Q)" + key + "(w)", value.w);
        }
        public static Quaternion GetQuaternion(string key, Quaternion defaultValue = new Quaternion())
        {
            return new Quaternion(
                PlayerPrefs.GetFloat("(Q)" + key + "(x)", defaultValue.x),
                PlayerPrefs.GetFloat("(Q)" + key + "(y)", defaultValue.y),
                PlayerPrefs.GetFloat("(Q)" + key + "(z)", defaultValue.z),
                PlayerPrefs.GetFloat("(Q)" + key + "(w)", defaultValue.w)
                );
        }
        public static void DeleteQuaternion(string key)
        {
            PlayerPrefs.DeleteKey("(Q)" + key + "(x)");
            PlayerPrefs.DeleteKey("(Q)" + key + "(y)");
            PlayerPrefs.DeleteKey("(Q)" + key + "(z)");
            PlayerPrefs.DeleteKey("(Q)" + key + "(w)");
        }

        public static void SetEnum<T>(string key, T value)
        {
            PlayerPrefs.SetInt("(" + typeof(T).ToString() + ")" + key, (int)System.Enum.ToObject(typeof(T), value));
        }
        public static T GetEnum<T>(string key)
        {
            return (T)System.Enum.Parse(typeof(T), PlayerPrefs.GetInt("(" + typeof(T).ToString() + ")" + key).ToString());
        }
        public static T GetEnum<T>(string key, T defaultValue)
        {
            int d = (int)System.Enum.ToObject(typeof(T), defaultValue);
            T temp = (T)System.Enum.Parse(typeof(T), PlayerPrefs.GetInt("(" + typeof(T).ToString() + ")" + key, d).ToString());
            return temp;
        }
        public static void DeleteEnum<T>(string key)
        {
            PlayerPrefs.DeleteKey("(" + typeof(T).ToString() + ")" + key);
        }

        public static void SetSerializedObject<T>(string key, T value)
        {
            string json = JsonUtility.ToJson(value);
            PlayerPrefs.SetString("(" + typeof(T).ToString() + ")" + key, json);
        }
        public static T GetSerializedObject<T>(string key)
        {
            string json = PlayerPrefs.GetString("(" + typeof(T).ToString() + ")" + key);
            return JsonUtility.FromJson<T>(json);
        }
        public static T GetSerializedObject<T>(string key, T defaultValue)
        {
            string json = PlayerPrefs.GetString("(" + typeof(T).ToString() + ")" + key);
            T data = JsonUtility.FromJson<T>(json);
            if (data == null)
                data = defaultValue;
            return data;
        }
        public static void DeleteSerializedObject<T>(string key)
        {
            PlayerPrefs.DeleteKey("(" + typeof(T).ToString() + ")" + key);
        }

        public static void SetColor(string key, Color value)
        {
            PlayerPrefs.SetFloat("(Color)" + key + "(r)", value.r);
            PlayerPrefs.SetFloat("(Color)" + key + "(g)", value.g);
            PlayerPrefs.SetFloat("(Color)" + key + "(b)", value.b);
            PlayerPrefs.SetFloat("(Color)" + key + "(a)", value.a);
        }
        public static Color GetColor(string key, Color defaultValue = new Color())
        {
            return new Color(
                PlayerPrefs.GetFloat("(Color)" + key + "(r)", defaultValue.r),
                PlayerPrefs.GetFloat("(Color)" + key + "(g)", defaultValue.g),
                PlayerPrefs.GetFloat("(Color)" + key + "(b)", defaultValue.b),
                PlayerPrefs.GetFloat("(Color)" + key + "(a)", defaultValue.a)
                );
        }
        public static void DeleteColor(string key)
        {
            PlayerPrefs.DeleteKey("(Color)" + key + "(r)");
            PlayerPrefs.DeleteKey("(Color)" + key + "(g)");
            PlayerPrefs.DeleteKey("(Color)" + key + "(b)");
            PlayerPrefs.DeleteKey("(Color)" + key + "(a)");
        }

    }
}