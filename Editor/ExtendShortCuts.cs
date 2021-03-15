using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Diagnostics;

namespace BIAB.Editor
{
    public class ExtendShortCuts
    {
        static void StartProcess(string path)
        {
            Process foo = new Process();
            foo.StartInfo.FileName = @path;
            foo.Start();
        }

        static void OpenWeb(string url)
        {
            Application.OpenURL(url);
        }
    }
}
