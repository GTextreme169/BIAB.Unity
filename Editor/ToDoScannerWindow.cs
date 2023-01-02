using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System;
using UnityEngine.Serialization;

namespace BIAB.Unity.Editor
{
    public class ToDoScannerWindow : EditorWindow
    {
        private Vector2 _scrollPos;
        private bool _showHidden = false;
        private static List<TDF> _hidden;

        private static TDF[] _toDoFiles;

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
            Save(_hidden, _toDoFiles);
        }

        void OnGUI()
        {
            float w = position.width;
            float wf = w;
            wf = wf / 500f;
            if (_hidden == null || _toDoFiles == null)
            {
                return;
            }

            GUILayout.BeginHorizontal();
            _showHidden = EditorGUILayout.Toggle("Show Hidden", _showHidden);
            if (GUILayout.Button("Refresh"))
            {
                Refresh();
            }
            GUILayout.EndHorizontal();

            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
            GUI.skin.label.alignment = TextAnchor.MiddleLeft;
            for (int i = 0; i < _toDoFiles.Length; i++)
            {
                bool h = _hidden.Contains(_toDoFiles[i]);
                if (h == false || _showHidden)
                {

                    GUILayout.BeginHorizontal();
                    EditorGUILayout.ObjectField(_toDoFiles[i].FileAsset, typeof(MonoScript), false, GUILayout.Width(100 * wf));
                    GUILayout.Label("Line: " + _toDoFiles[i].line.ToString(), GUILayout.Width(65));
                    GUILayout.Label(_toDoFiles[i].msg, GUILayout.MaxWidth(w - 65 - (wf * 217.5f)));
                    if (GUILayout.Button("Go To", GUILayout.Width(50 * wf))) AssetDatabase.OpenAsset(_toDoFiles[i].FileAsset, _toDoFiles[i].line);
                    if (h)
                    {
                        if (GUILayout.Button("Show", GUILayout.Width(50 * wf)))
                        {
                            _hidden.Remove(_toDoFiles[i]);
                            Save(_hidden, _toDoFiles);
                        }
                    }
                    else
                    {
                        if (GUILayout.Button("Hide", GUILayout.Width(50 * wf)))
                        {
                            _hidden.Add(_toDoFiles[i]);
                            Save(_hidden, _toDoFiles);
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
            _hidden = Load();
        }

        static void Save(List<TDF> list, TDF[] confirmedArr)
        {
            File.Delete(Application.dataPath.Replace("Assets", "hiddenTD.json"));
            List<string> json = new List<string>();
            List<TDF> confirmed = new List<TDF>();
            confirmed.AddRange(confirmedArr);
            foreach (var t in list)
            {
                if (confirmed.Contains(t))
                    json.Add(JsonUtility.ToJson(t));
            }

            File.WriteAllLines(Application.dataPath.Replace("Assets", "hiddenTD.json"), json);
        }

        static List<TDF> Load()
        {
            string filePath = Application.dataPath.Replace("Assets", "hiddenTD.json");
            string[] json = Array.Empty<string>();
            if (File.Exists(filePath))
                json = File.ReadAllLines(filePath);
            List<TDF> list = new List<TDF>();
            foreach (var t in json)
            {
                TDF temp = JsonUtility.FromJson<TDF>(t);
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
                        TDF tdf = new TDF
                        {
                            msg = lines[i].Replace("//TODO", "").Trim(),
                            file = "Assets/" + file.Replace(Application.dataPath, "")
                        };
                        tdf.FileAsset = AssetDatabase.LoadAssetAtPath<MonoScript>(tdf.file);
                        tdf.line = (i + 1);
                        tds.Add(tdf);
                    }
                    else
                    if (lines[i].Contains("NotImplementedException") && file.Contains("ToDoScanner") == false)
                    {
                        TDF tdf = new TDF
                        {
                            msg = "Not Implemented Exception",
                            file = "Assets/" + file.Replace(Application.dataPath, "")
                        };
                        tdf.FileAsset = AssetDatabase.LoadAssetAtPath<MonoScript>(tdf.file);
                        tdf.line = (i + 1);
                        tds.Add(tdf);
                    }
                }
            }

            _toDoFiles = tds.ToArray();
            _hidden = Load();
        }
    }

    [Serializable]
    struct TDF
    {
        [FormerlySerializedAs("Msg")] 
        public string msg;
        public string file;
        [NonSerialized]
        public MonoScript FileAsset;
        public int line;
    }
}