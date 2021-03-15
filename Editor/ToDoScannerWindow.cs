using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System;

namespace BIAB.Editor
{
    public class ToDoScannerWindow : EditorWindow
    {
        Vector2 scrollPos;
        bool showHidden = false;
        static List<TDF> Hidden;

        static TDF[] ToDoFiles;

        // Add menu named "My Window" to the Window menu
        [MenuItem("Window/To Do Files")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            ToDoScannerWindow window = (ToDoScannerWindow)EditorWindow.GetWindow(typeof(ToDoScannerWindow));
            window.Show();
        }

        private void Awake()
        {
            Refresh();
        }
        [UnityEditor.Callbacks.DidReloadScripts]
        public static void OnProjectChanged()
        {
            Refresh();
            Save(Hidden, ToDoFiles);
        }

        void OnGUI()
        {
            float w = position.width;
            float wf = w;
            wf = wf / 500f;
            if (Hidden == null || ToDoFiles == null)
            {
                return;
            }

            GUILayout.BeginHorizontal();
            showHidden = EditorGUILayout.Toggle("Show Hidden", showHidden);
            if (GUILayout.Button("Refresh"))
            {
                Refresh();
            }
            GUILayout.EndHorizontal();

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
            GUI.skin.label.alignment = TextAnchor.MiddleLeft;
            for (int i = 0; i < ToDoFiles.Length; i++)
            {
                bool h = Hidden.Contains(ToDoFiles[i]);
                if (h == false || showHidden)
                {

                    GUILayout.BeginHorizontal();
                    EditorGUILayout.ObjectField(ToDoFiles[i].FileAsset, typeof(MonoScript), false, GUILayout.Width(100 * wf));
                    GUILayout.Label("Line: " + ToDoFiles[i].line.ToString(), GUILayout.Width(65));
                    GUILayout.Label(ToDoFiles[i].Msg, GUILayout.MaxWidth(w - 65 - (wf * 217.5f)));
                    if (GUILayout.Button("Go To", GUILayout.Width(50 * wf))) AssetDatabase.OpenAsset(ToDoFiles[i].FileAsset, ToDoFiles[i].line);
                    if (h)
                    {
                        if (GUILayout.Button("Show", GUILayout.Width(50 * wf)))
                        {
                            Hidden.Remove(ToDoFiles[i]);
                            Save(Hidden, ToDoFiles);
                        }
                    }
                    else
                    {
                        if (GUILayout.Button("Hide", GUILayout.Width(50 * wf)))
                        {
                            Hidden.Add(ToDoFiles[i]);
                            Save(Hidden, ToDoFiles);
                        }
                    }
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space();
                }
            }
            EditorGUILayout.EndScrollView();

        }

        static void Refresh()
        {

            Scan();
            Hidden = Load();
        }

        static void Save(List<TDF> list, TDF[] confirmedArr)
        {
            File.Delete(Application.dataPath.Replace("Assets", "hiddenTD.json"));
            List<string> json = new List<string>();
            List<TDF> confirmed = new List<TDF>();
            confirmed.AddRange(confirmedArr);
            for (int i = 0; i < list.Count; i++)
            {
                if (confirmed.Contains(list[i]))
                    json.Add(JsonUtility.ToJson(list[i]));
            }

            File.WriteAllLines(Application.dataPath.Replace("Assets", "hiddenTD.json"), json);
        }

        static List<TDF> Load()
        {
            string filePath = Application.dataPath.Replace("Assets", "hiddenTD.json");
            string[] json = new string[0];
            if (File.Exists(filePath))
                json = File.ReadAllLines(filePath);
            List<TDF> list = new List<TDF>();
            for (int i = 0; i < json.Length; i++)
            {
                TDF temp = JsonUtility.FromJson<TDF>(json[i]);
                temp.FileAsset = AssetDatabase.LoadAssetAtPath<MonoScript>(temp.file);
                list.Add(temp);
            }
            return list;
        }


        static void Scan()
        {
            string[] files = Directory.GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories);
            List<TDF> tds = new List<TDF>();
            foreach (string file in files)
            {
                string[] lines = File.ReadAllLines(file);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains("//TODO") && file.Contains("ToDoScanner") == false)
                    {
                        TDF tdf = new TDF();
                        tdf.Msg = lines[i].Replace("//TODO", "").Trim();
                        tdf.file = "Assets/" + file.Replace(Application.dataPath, "");
                        tdf.FileAsset = AssetDatabase.LoadAssetAtPath<MonoScript>(tdf.file);
                        tdf.line = (i + 1);
                        tds.Add(tdf);
                    }
                    else
                    if (lines[i].Contains("NotImplementedException") && file.Contains("ToDoScanner") == false)
                    {
                        TDF tdf = new TDF();
                        tdf.Msg = "Not Implemented Exception";
                        tdf.file = "Assets/" + file.Replace(Application.dataPath, "");
                        tdf.FileAsset = AssetDatabase.LoadAssetAtPath<MonoScript>(tdf.file);
                        tdf.line = (i + 1);
                        tds.Add(tdf);
                    }
                }
            }

            ToDoFiles = tds.ToArray();
            Hidden = Load();
        }
    }

    [Serializable]
    struct TDF
    {
        public string Msg;
        public string file;
        [NonSerialized]
        public MonoScript FileAsset;
        public int line;
    }
}