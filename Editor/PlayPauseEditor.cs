/* Made By: Trevin Pointer
 * Description: A simple Play/Pause Button Shortcut
 * Notes: You Can Change The ShortCut By Replacing the "_END" with whatever keybindings
 * Example Bindings: https://docs.unity3d.com/ScriptReference/MenuItem.html
 * Install: Place script under Assets/Editor Folder
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace BIAB.Unity.Editor
{
    public class PlayPauseEditor : ScriptableObject
    {

        [MenuItem("Tools/BIAB/ShortCuts/Play-Pause _END")]
        static void PlayGame()
        {
            if (!EditorApplication.isPlaying) EditorSceneManager.SaveScene(SceneManager.GetActiveScene(), "", false);
            //EditorApplication.isPlaying = !EditorApplication.isPlaying;
            EditorApplication.ExecuteMenuItem("Edit/Play");
        }
    }
}