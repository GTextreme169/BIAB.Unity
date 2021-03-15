/* Made By: Trevin Pointer
 * Description: A simple PlayerPref Editor Addition
 * Notes: Will be Overwritten if ExtendedPref Editor is Installed
 * Install: Place script under Assets/Editor Folder
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if ExtendedPlayerPrefsWindow_EXISTS
namespace BIAB.Editor 
{
public class PlayerPrefsWindow : EditorWindow {
    string menu = "";
    int fieldWidth = 150;

    // Add/Remove Pref
    int variableTypeInt = 0;
    string variableName = "";
    bool toggle = false;
    string valueString = "";
    int valueInt = 0;
    float valueFloat = 0;
    Vector3 valueVector3 = new Vector3();

    [MenuItem("Tools/PlayerPrefs/Reset")]
    static void ResetPP()
    {
        // Get existing open window or if none, make a new one:
        PlayerPrefsWindow window = (PlayerPrefsWindow)EditorWindow.GetWindow(typeof(PlayerPrefsWindow));
        window.Show();
        window.menu = "reset";
    }
    [MenuItem("Tools/PlayerPrefs/Add")]
    static void AddPP()
    {
        PlayerPrefsWindow window = (PlayerPrefsWindow)EditorWindow.GetWindow(typeof(PlayerPrefsWindow));
        window.Show();
        window.menu = "add";
    }
    [MenuItem("Tools/PlayerPrefs/Edit")]
    static void EditPP()
    {
        PlayerPrefsWindow window = (PlayerPrefsWindow)EditorWindow.GetWindow(typeof(PlayerPrefsWindow));
        window.Show();
        window.menu = "edit";
    }
    [MenuItem("Tools/PlayerPrefs/Remove")]
    static void RemovePP()
    {
        PlayerPrefsWindow window = (PlayerPrefsWindow)EditorWindow.GetWindow(typeof(PlayerPrefsWindow));
        window.Show();
        window.menu = "remove";
    }

    void EditGUI()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button(((VariableTypes) variableTypeInt).ToString()))
            variableTypeInt++;

        // No Overflow
        if (variableTypeInt > 2) variableTypeInt = 0;
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Name: ");
        variableName = EditorGUILayout.TextField(variableName, GUILayout.Width(fieldWidth));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (((VariableTypes) variableTypeInt) == VariableTypes.String)
        {
            GUILayout.Label("Value: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth));
        }

        if (((VariableTypes) variableTypeInt) == VariableTypes.Integer)
        {
            GUILayout.Label("Value: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth));
            int.TryParse(valueString, out valueInt);
        }

        if (((VariableTypes) variableTypeInt) == VariableTypes.Float)
        {
            GUILayout.Label("Value: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth));
            float.TryParse(valueString, out valueFloat);
        }

        GUILayout.EndHorizontal();
    }

    void Save()
    {
        if (((VariableTypes)variableTypeInt) == VariableTypes.String)
            PlayerPrefs.SetString(variableName, valueString);
        if (((VariableTypes)variableTypeInt) == VariableTypes.Integer)
            PlayerPrefs.SetInt(variableName, valueInt);
        if (((VariableTypes)variableTypeInt) == VariableTypes.Float)
            PlayerPrefs.SetFloat(variableName, valueFloat);
        this.Close();
    }

    void Load()
    {
        if (((VariableTypes)variableTypeInt) == VariableTypes.String)
            valueString = PlayerPrefs.GetString(variableName, valueString);
        if (((VariableTypes)variableTypeInt) == VariableTypes.Integer)
            valueInt = PlayerPrefs.GetInt(variableName, valueInt);
        if (((VariableTypes)variableTypeInt) == VariableTypes.Float)
            valueFloat = PlayerPrefs.GetFloat(variableName, valueFloat);
    }

    void GUIReset()
    {
        GUILayout.Label("Reset All Player Prefs?", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Yes"))
        {
            PlayerPrefs.DeleteAll();
            this.Close();
        }
        if (GUILayout.Button("No"))
        {
            this.Close();
        }
        GUILayout.EndHorizontal();
    }

    void GUIAdd()
    {
        GUILayout.Label("New PlayerPref", EditorStyles.boldLabel);
        EditGUI();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Apply"))
        {
            Save();
        }
        if (GUILayout.Button("Cancel")) this.Close();

        GUILayout.EndHorizontal();
    }

    void GUIEdit()
    {
        GUILayout.Label("Edit PlayerPref", EditorStyles.boldLabel);
        EditGUI();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Load")) Load();
            
        if (GUILayout.Button("Save"))
        {
            Save();
        }
        if (GUILayout.Button("Cancel")) this.Close();

        GUILayout.EndHorizontal(); 
    }

    void GUIRemove()
    {
        GUILayout.Label("New PlayerPref", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button(((VariableTypes)variableTypeInt).ToString()))
            variableTypeInt++;

        // No Overflow
        if (variableTypeInt > 2) variableTypeInt = 0;
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Name: ");
        variableName = EditorGUILayout.TextField(variableName, GUILayout.Width(fieldWidth));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Remove"))
        {
            PlayerPrefs.DeleteKey(variableName);
            this.Close();
        }
        if (GUILayout.Button("Cancel")) this.Close();

        GUILayout.EndHorizontal();
    }

    void OnGUI()
    {
        if (menu == "reset")
            GUIReset();
        if (menu == "add")
            GUIAdd();
        if (menu == "edit")
            GUIEdit();
        if (menu == "remove")
            GUIRemove();
    }
    
}
enum VariableTypes
{
    String,
    Integer,
    Float
};
}
#endif