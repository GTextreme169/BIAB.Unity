using UnityEngine;
using System.Diagnostics;

namespace BIAB.Unity.Editor
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
