using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace BIAB.Editor
{
    public class MultiBuild : EditorWindow
    {
        RuntimePlatform[] All = new RuntimePlatform[] { RuntimePlatform.WindowsPlayer, RuntimePlatform.LinuxPlayer, RuntimePlatform.OSXPlayer, RuntimePlatform.Android, RuntimePlatform.WebGLPlayer };
        List<RuntimePlatform> Selected = new List<RuntimePlatform>();
        static string Version;
        static int VersionNumber;
        static string GameName;
        static bool Build32 = true;
        static bool Build64 = true;
        static bool Once = false;
        
        private UnityEditor.BuildTarget previousTarget;
        private string previousScene;
        private string projectPath;
        

        [MenuItem("File/Multi-Builder")]
        static void Init()
        {
            MultiBuild window = (MultiBuild)EditorWindow.GetWindow(typeof(MultiBuild));
            window.Show();
            VersionNumber = EditorPrefs.GetInt("GameVersionNumber", 1);
            Version = EditorPrefs.GetString("GameVersion", "1");
            GameName = EditorPrefs.GetString("GameName", "Game");
        }

        #region GUI
        
        void OnGUI()
        {
            GUIResetButton();
            EditorGUILayout.LabelField("Platforms: ");
            GUIListPlatformBools();
            GUITextFields();
            GUISetRefreshButtons();
            EditorGUILayout.Space();
            GUIArchButton();
            EditorGUILayout.Space();
            GUIBuildButton();

        }

        void GUIResetButton()
        {
            if (GUILayout.Button("Reset"))
            {
                Build32 = true;
                Build64 = true;
                for (int i = 0; i < All.Length; i++)
                {
                    Selected.Add(All[i]);
                }
            }
        }

        void GUITextFields()
        {
            Version = EditorGUILayout.TextField("Version: ", Version);
            VersionNumber = EditorGUILayout.IntField("Version #: ", VersionNumber);
            GameName = EditorGUILayout.TextField("Name: ", GameName);

            if (Selected.Contains(RuntimePlatform.Android))
            {
                if (PlayerSettings.Android.keystoreName != "")
                    PlayerSettings.Android.keyaliasPass = PlayerSettings.keystorePass = EditorGUILayout.TextField("KeyStore: ", PlayerSettings.keystorePass);
            }
        }
        
        void GUISetRefreshButtons()
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Set"))
            {
                PlayerSettings.bundleVersion = Version;
                PlayerSettings.Android.bundleVersionCode = VersionNumber;
                EditorPrefs.SetString("GameVersion", Version);
                EditorPrefs.SetInt("GameVersionNumber", VersionNumber);
                EditorPrefs.SetString("GameName", GameName);
            }
            if (GUILayout.Button("Refresh"))
            {
                VersionNumber = EditorPrefs.GetInt("GameVersionNumber", 1);
                Version = EditorPrefs.GetString("GameVersion", "1");
                GameName = EditorPrefs.GetString("GameName", "Game");
            }
            EditorGUILayout.EndHorizontal();
        }
        
        void GUIListPlatformBools()
        {
            for (int i = 0; i < All.Length; i++)
            {
                bool TempBool = Selected.Contains(All[i]);
                bool Final = TempBool;
                TempBool = EditorGUILayout.Toggle(All[i].ToString(), TempBool);
                if (Final)
                {
                    if (TempBool == false)
                    {
                        Selected.Remove(All[i]);
                    }
                }
                else
                {
                    if (TempBool == true)
                    {
                        Selected.Add(All[i]);
                    }
                }
            }
        }

        void GUIArchButton()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Arch: ");
            if (Build64 == true)
            {
                if (Build32 == true)
                {
                    if (GUILayout.Button("All"))
                    {
                        Build64 = false;
                    }
                }
                else
                {
                    if (GUILayout.Button("64 bit"))
                    {
                        Build32 = true;
                    }
                }

            }
            else
            {
                if (GUILayout.Button("32 bit"))
                {
                    Build64 = true;
                    Build32 = false;
                }
            }

            EditorGUILayout.EndHorizontal();
        }

        void GUIBuildButton()
        {
            if (Version != "" && GameName != "" && VersionNumber > 0)
            {
                if (!EditorApplication.isCompiling)
                {
                    if (GUILayout.Button("Build Selected Platforms"))
                    {

                        Build();
                    }
                }
                else
                {
                    GUILayout.Label("Please Wait. Unity is Compiling Assets.");
                }
            }
            else
            {
                GUILayout.Label("Variables Not Set Correctly");
            }
        }
        
        #endregion

        
        void OnFocus()
        {
            VersionNumber = EditorPrefs.GetInt("GameVersionNumber", 1);
            Version = EditorPrefs.GetString("GameVersion", "1");
            GameName = EditorPrefs.GetString("GameName", "Game");
        }

        string[] GetScenes()
        {
            List<string> Tempscenes = new List<string>();
            for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
            {
                if (EditorBuildSettings.scenes[i].enabled)
                {
                    Tempscenes.Add(EditorBuildSettings.scenes[i].path);
                }
            }
            return Tempscenes.ToArray();
        }
        
        void Build()
        {
            if (EditorBuildSettings.scenes.Length == 0)
            {
                Debug.Log("No Scenes Added To Build!");
                return;
            }

            previousTarget = EditorUserBuildSettings.activeBuildTarget;
            previousScene = EditorApplication.currentScene;
            projectPath = Application.dataPath.Replace("Assets", "Builds");
            
            //UnityEditor.SceneManagement.EditorSceneManager.OpenScene(EditorBuildSettings.scenes[0].path, UnityEditor.SceneManagement.OpenSceneMode.Single);
            EditorApplication.SaveScene();
            
            // the scenes we want to include in the build
            string[] scenes = GetScenes();
            
            foreach (RuntimePlatform Platform in Selected)
            {
                BuildWindows(Platform, scenes);
                BuildLinux(Platform, scenes);
                BuildOSX(Platform, scenes);
                BuildAndroid(Platform, scenes);
                BuildWebGL(Platform, scenes);
            }
            
            //Return
            EditorUserBuildSettings.SwitchActiveBuildTarget(previousTarget);
            UnityEditor.SceneManagement.EditorSceneManager.OpenScene(previousScene, UnityEditor.SceneManagement.OpenSceneMode.Single);
        }

        #region BuildFunctions

        void BuildWebGL(RuntimePlatform Platform, string[] scenes)
        {
            if(Platform != RuntimePlatform.WebGLPlayer)
                return;
            
            string Path = projectPath + "/WebGL/";
            string Name = Path + "/" + Version;
            FixDirectory(Path);
            BuildPipeline.BuildPlayer(scenes, Name, BuildTarget.WebGL, BuildOptions.None);
        }
        
        void BuildAndroid(RuntimePlatform Platform, string[] scenes)
        {
            if(Platform != RuntimePlatform.Android)
                return;
            
            string Path = projectPath + "/Android/";
            string Name = Path + "/" + GameName + " " + Version;
            FixDirectory(Path);
            BuildPipeline.BuildPlayer(scenes, Name, BuildTarget.Android, BuildOptions.None);
        }
        
        void BuildOSX(RuntimePlatform Platform, string[] scenes)
        {
            if(Platform != RuntimePlatform.OSXPlayer)
                return;
            
            string Path = projectPath + "/Mac/" + Version + "/";
            string Name = Path + "/" + GameName + ".app";
            FixDirectory(Path);
            BuildPipeline.BuildPlayer(scenes, Name, BuildTarget.StandaloneOSX, BuildOptions.None);
        }
        
        void BuildLinux(RuntimePlatform Platform, string[] scenes)
        {
            if(Platform != RuntimePlatform.LinuxPlayer)
                return;
            
            if (Build32)
            {
                string Path = projectPath + "/Linux32/" + Version + "/";
                string Name = Path + "/" + GameName + ".x86";
                FixDirectory(Path);
                BuildPipeline.BuildPlayer(scenes, Name, BuildTarget.StandaloneLinux, BuildOptions.None);
            }
            if (Build64)
            {
                string Path = projectPath + "/Linux64/" + Version + "/";
                string Name = Path + "/" + GameName + ".x86_64";
                FixDirectory(Path);
                BuildPipeline.BuildPlayer(scenes, Name, BuildTarget.StandaloneLinux64, BuildOptions.None);
            }
        }
        void BuildWindows(RuntimePlatform Platform, string[] scenes)
        {
            if(Platform != RuntimePlatform.WindowsPlayer)
                return;
            
            if (Build32)
            {
                string Path = projectPath + "/Windows32/" + Version + "/";
                string Name = Path + "/" + GameName + ".exe";
                FixDirectory(Path);
                BuildPipeline.BuildPlayer(scenes, Name, BuildTarget.StandaloneWindows, BuildOptions.None);
            }
            if (Build64)
            {
                string Path = projectPath + "/Windows64/" + Version + "/";
                string Name = Path + "/" + GameName + ".exe";
                FixDirectory(Path);
                BuildPipeline.BuildPlayer(scenes, Name, BuildTarget.StandaloneWindows64, BuildOptions.None);
            }
        }
        
        #endregion
        
        void FixDirectory(string Path, bool destroy = false)
        {
            if (System.IO.Directory.Exists(Path))
            {
                if (destroy)
                {
                    System.IO.Directory.Delete(Path);
                    System.IO.Directory.CreateDirectory(Path);
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(Path);
            }
        }

    }
}