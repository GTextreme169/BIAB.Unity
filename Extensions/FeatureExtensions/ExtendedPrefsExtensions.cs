using BIAB.Unity.Other;
using UnityEngine;

namespace BIAB.Unity.Extensions
{
    public static class ExtendedPrefsExtensions
    {
        /// <summary>
        /// Saves Position Of Transform Based On Name Of GameObject
        /// </summary>
        /// <param name="transform"></param>
        public static void SavePosition(this Transform transform)
        {
            ExtendedPrefs.SetVector3(transform.gameObject.name, transform.position);
        }

        /// <summary>
        /// Saves Position Of Transform Based On a Key
        /// </summary>
        /// <param name="transform"></param>
        public static void SavePosition(this Transform transform, string key)
        {
            ExtendedPrefs.SetVector3(key, transform.position);
        }

        /// <summary>
        /// Loads Position Of Transform Based On Name Of GameObject
        /// </summary>
        /// <param name="transform"></param>
        public static void LoadPosition(this Transform transform)
        {
            transform.position = ExtendedPrefs.GetVector3(transform.gameObject.name, transform.position);
        }

        /// <summary>
        /// Loads Position Of Transform Based On a Key
        /// </summary>
        /// <param name="transform"></param>
        public static void LoadPosition(this Transform transform, string key)
        {
            transform.position = ExtendedPrefs.GetVector3(key, transform.position);
        }

        public static void SaveLocalPosition(this Transform transform)
        {
            ExtendedPrefs.SetVector3(transform.gameObject.name, transform.localPosition);
        }

        public static void SaveLocalPosition(this Transform transform, string key)
        {
            ExtendedPrefs.SetVector3(key, transform.localPosition);
        }

        public static void LoadLocalPosition(this Transform transform)
        {
            transform.localPosition = ExtendedPrefs.GetVector3(transform.gameObject.name, transform.localPosition);
        }

        public static void LoadLocalPosition(this Transform transform, string key)
        {
            transform.localPosition = ExtendedPrefs.GetVector3(key, transform.localPosition);
        }

        public static void SaveRotation(this Transform transform)
        {
            ExtendedPrefs.SetQuaternion(transform.gameObject.name, transform.rotation);
        }

        public static void SaveRotation(this Transform transform, string key)
        {
            ExtendedPrefs.SetQuaternion(key, transform.rotation);
        }

        public static void LoadRotation(this Transform transform)
        {
            transform.rotation = ExtendedPrefs.GetQuaternion(transform.gameObject.name, transform.rotation);
        }

        public static void LoadRotation(this Transform transform, string key)
        {
            transform.rotation = ExtendedPrefs.GetQuaternion(key, transform.rotation);
        }

        public static void SaveLocalRotation(this Transform transform)
        {
            ExtendedPrefs.SetQuaternion(transform.gameObject.name, transform.localRotation);
        }

        public static void SaveLocalRotation(this Transform transform, string key)
        {
            ExtendedPrefs.SetQuaternion(key, transform.localRotation);
        }

        public static void LoadLocalRotation(this Transform transform)
        {
            transform.localRotation = ExtendedPrefs.GetQuaternion(transform.gameObject.name, transform.localRotation);
        }

        public static void LoadLocalRotation(this Transform transform, string key)
        {
            transform.localRotation = ExtendedPrefs.GetQuaternion(key, transform.localRotation);
        }

        public static void SaveLocalScale(this Transform transform)
        {
            ExtendedPrefs.SetVector3(transform.gameObject.name, transform.localScale);
        }

        public static void SaveLocalScale(this Transform transform, string key)
        {
            ExtendedPrefs.SetVector3(key, transform.localScale);
        }

        public static void LoadLocalScale(this Transform transform)
        {
            transform.localScale = ExtendedPrefs.GetVector3(transform.gameObject.name, transform.localScale);
        }

        public static void LoadLocalScale(this Transform transform, string key)
        {
            transform.localScale = ExtendedPrefs.GetVector3(key, transform.localScale);
        }
    }
}