/* Made By: Trevin Pointer
 * Description: A simple Extended PlayerPref Editor Addition
 * Notes: Will be Overwrite PlayerPref Editor if it is installed
 * Install: Place script under Assets/Editor Folder
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BIAB.Editor
{
    public class ExtendedPlayerPrefsWindow : EditorWindow
    {
        string menu = "";
        int fieldWidth = 150;

        // Add/Remove Pref
        int variableTypeInt = 0;
        string variableName = "";
        bool valueBool = false;
        string valueString = "";
        int valueInt = 0;
        float valueFloat = 0;
        Vector2 valueVector2 = new Vector2();
        Vector3 valueVector3 = new Vector3();
        Vector4 valueVector4 = new Vector4();
        Quaternion valueQuat = new Quaternion();
        Color valueColor = new Color();
    #region Toolbar
        [MenuItem("Tools/PlayerPrefs/Reset")]
        static void ResetPP()
        {
            // Get existing open window or if none, make a new one:
            ExtendedPlayerPrefsWindow window = (ExtendedPlayerPrefsWindow)EditorWindow.GetWindow(typeof(ExtendedPlayerPrefsWindow));
            window.Show();
            window.menu = "reset";
        }
        [MenuItem("Tools/PlayerPrefs/Add")]
        static void AddPP()
        {
            ExtendedPlayerPrefsWindow window = (ExtendedPlayerPrefsWindow)EditorWindow.GetWindow(typeof(ExtendedPlayerPrefsWindow));
            window.Show();
            window.menu = "add";
        }
        [MenuItem("Tools/PlayerPrefs/Edit")]
        static void EditPP()
        {
            ExtendedPlayerPrefsWindow window = (ExtendedPlayerPrefsWindow)EditorWindow.GetWindow(typeof(ExtendedPlayerPrefsWindow));
            window.Show();
            window.menu = "edit";
        }
        [MenuItem("Tools/PlayerPrefs/Remove")]
        static void RemovePP()
        {
            ExtendedPlayerPrefsWindow window = (ExtendedPlayerPrefsWindow)EditorWindow.GetWindow(typeof(ExtendedPlayerPrefsWindow));
            window.Show();
            window.menu = "remove";
        }

        #endregion
        
        
        void OnGUI()
        {
            switch (menu)
            {
                case "reset":
                    ResetGUI();
                    break;
                case "add":
                    AddGUI();
                    break;
                case "edit":
                    EditGUI();
                    break;
                case "remove":
                    RemoveGUI();
                    break;
            }
        }

        private void RemoveGUI()
        {
            GUILayout.Label("Remove PlayerPref", EditorStyles.boldLabel);
            VariableTypes variableType = TypeFieldLogic();
            NameField();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Remove"))
            {
                RemoveVariable(variableType);
                this.Close();
            }

            if (GUILayout.Button("Cancel")) this.Close();

            GUILayout.EndHorizontal();
        }
        


        void ResetGUI()
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
        
        void AddGUI()
        {
            GUILayout.Label("New PlayerPref", EditorStyles.boldLabel);
            VariableTypes variableType = TypeFieldLogic();
            NameField();
            EditField(variableType);

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Apply"))
            { 
                SetVariable(variableType); 
                this.Close();
            }
            if (GUILayout.Button("Cancel")) this.Close();

            GUILayout.EndHorizontal();
        }

        void EditGUI()
        {
            GUILayout.Label("Edit PlayerPref", EditorStyles.boldLabel);
            VariableTypes variableType = TypeFieldLogic();
            NameField();
            EditField(variableType);

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Load"))
            {
                GetVariable(variableType);
            }

            if (GUILayout.Button("Save"))
            {
                SetVariable(variableType);
                this.Close();
            }

            if (GUILayout.Button("Cancel")) this.Close();

            GUILayout.EndHorizontal();
        }

        #region Support Functions
        
        void RemoveVariable(VariableTypes variableType)
        {
            switch (variableType)
            {
                case VariableTypes.String:
                    ExtendedPrefs.DeleteString(variableName);
                    break;
                case VariableTypes.Integer:
                    ExtendedPrefs.DeleteInt(variableName);
                    break;
                case VariableTypes.Float:
                    ExtendedPrefs.DeleteFloat(variableName);
                    break;
                case VariableTypes.Boolean:
                    ExtendedPrefs.DeleteBool(variableName);
                    break;
                case VariableTypes.Vector2:
                    ExtendedPrefs.DeleteVector2(variableName);
                    break;
                case VariableTypes.Vector3:
                    ExtendedPrefs.DeleteVector3(variableName);
                    break;
                case VariableTypes.Vector4:
                    ExtendedPrefs.DeleteVector4(variableName);
                    break;
                case VariableTypes.Quaternion:
                    ExtendedPrefs.DeleteQuaternion(variableName);
                    break;
                case VariableTypes.Color:
                    ExtendedPrefs.DeleteColor(variableName);
                    break;
            }
        }
        
        void SetVariable(VariableTypes variableType)
            {
                switch (variableType)
                {
                    case VariableTypes.String:
                        ExtendedPrefs.SetString(variableName, valueString);
                        break;
                    case VariableTypes.Integer:
                        ExtendedPrefs.SetInt(variableName, valueInt);
                        break;
                    case VariableTypes.Float:
                        ExtendedPrefs.SetFloat(variableName, valueFloat);
                        break;
                    case VariableTypes.Boolean:
                        ExtendedPrefs.SetBool(variableName, valueBool);
                        break;
                    case VariableTypes.Vector2:
                        ExtendedPrefs.SetVector2(variableName, valueVector2);
                        break;
                    case VariableTypes.Vector3:
                        ExtendedPrefs.SetVector3(variableName, valueVector3);
                        break;
                    case VariableTypes.Vector4:
                        ExtendedPrefs.SetVector4(variableName, valueVector4);
                        break;
                    case VariableTypes.Quaternion:
                        ExtendedPrefs.SetQuaternion(variableName, valueQuat);
                        break;
                    case VariableTypes.Color:
                        ExtendedPrefs.SetColor(variableName, valueColor);
                        break;
                }
            }

        void GetVariable(VariableTypes variableType)
        {
            switch (variableType)
            {
                case VariableTypes.String:
                    valueString = ExtendedPrefs.GetString(variableName, valueString);
                    break;
                case VariableTypes.Integer:
                    valueInt = ExtendedPrefs.GetInt(variableName, valueInt);
                    break;
                case VariableTypes.Float:
                    valueFloat = ExtendedPrefs.GetFloat(variableName, valueFloat);
                    break;
                case VariableTypes.Boolean:
                    valueBool = ExtendedPrefs.GetBool(variableName, valueBool);
                    break;
                case VariableTypes.Vector2:
                    valueVector2 = ExtendedPrefs.GetVector2(variableName, valueVector2);
                    break;
                case VariableTypes.Vector3:
                    valueVector3 = ExtendedPrefs.GetVector3(variableName, valueVector3);
                    break;
                case VariableTypes.Vector4:
                    valueVector4 = ExtendedPrefs.GetVector4(variableName, valueVector4);
                    break;
                case VariableTypes.Quaternion:
                    valueQuat = ExtendedPrefs.GetQuaternion(variableName, valueQuat);
                    break;
                case VariableTypes.Color:
                    valueColor = ExtendedPrefs.GetColor(variableName, valueColor);
                    break;
            }
        }

        VariableTypes TypeFieldLogic()
        {
            GUILayout.BeginHorizontal();
            
            if (GUILayout.Button(((VariableTypes)variableTypeInt).ToString()))
                variableTypeInt++;
            
            // No Overflow
            if (variableTypeInt > 8) variableTypeInt = 0;
            
            GUILayout.EndHorizontal(); 
            return (VariableTypes)variableTypeInt;
        }

        void NameField()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Name: ");
            variableName = EditorGUILayout.TextField(variableName, GUILayout.Width(fieldWidth));
            GUILayout.EndHorizontal();
        }

        void EditField(VariableTypes variableType)
        {
            GUILayout.BeginHorizontal();
            switch (variableType)
            {
                case VariableTypes.String:
                    ShowEditString();
                    break;
                case VariableTypes.Integer:
                    ShowEditInt();
                    break;
                case VariableTypes.Float:
                    ShowEditFloat();
                    break;
                case VariableTypes.Boolean:
                    ShowEditBoolean();
                    break;
                case VariableTypes.Vector2:
                    ShowEditVector2();
                    break;
                case VariableTypes.Vector3:
                    ShowEditVector3();
                    break;
                case VariableTypes.Vector4:
                    ShowEditVector4();
                    break;
                case VariableTypes.Quaternion:
                    ShowEditQuaternion();
                    break;
                case VariableTypes.Color:
                    ShowEditColor();
                    break;
            }
            GUILayout.EndHorizontal();
        }
        #endregion
        
        #region Edit Fields
        void ShowEditBoolean()
        {
            GUILayout.Label("Value: ");
            valueBool = EditorGUILayout.Toggle(valueBool);
        }
        
        void ShowEditString()
        {
            GUILayout.Label("Value: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth));
        }
        void ShowEditInt()
        {
            GUILayout.Label("Value: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth));
            int.TryParse(valueString, out valueInt);
            
        }
        void ShowEditFloat()
        {
            GUILayout.Label("Value: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth));
            float.TryParse(valueString, out valueFloat);
        }

        void ShowEditVector2()
        {
            GUILayout.Label("x: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 2));
            float.TryParse(valueString, out valueVector2.x);
            GUILayout.Label("y: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 2));
            float.TryParse(valueString, out valueVector2.y);
            
        }
        void ShowEditVector3()
        {
            GUILayout.Label("x: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 3));
            float.TryParse(valueString, out valueVector3.x);
            GUILayout.Label("y: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 3));
            float.TryParse(valueString, out valueVector3.y);
            GUILayout.Label("z: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 3));
            float.TryParse(valueString, out valueVector3.z);
            
        }
        void ShowEditVector4()
        {
            GUILayout.Label("x: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 4));
            float.TryParse(valueString, out valueVector4.x);
            GUILayout.Label("y: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 4));
            float.TryParse(valueString, out valueVector4.y);
            GUILayout.Label("z: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 4));
            float.TryParse(valueString, out valueVector4.z);
            GUILayout.Label("w: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 4));
            float.TryParse(valueString, out valueVector4.w);
        }

        void ShowEditQuaternion()
        {
            GUILayout.Label("x: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 4));
            float.TryParse(valueString, out valueQuat.x);
            GUILayout.Label("y: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 4));
            float.TryParse(valueString, out valueQuat.y);
            GUILayout.Label("z: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 4));
            float.TryParse(valueString, out valueQuat.z);
            GUILayout.Label("w: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 4));
            float.TryParse(valueString, out valueQuat.w);
        }
        

        void ShowEditColor()
        {
            GUILayout.Label("r: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 4));
            float.TryParse(valueString, out valueColor.r);
            GUILayout.Label("g: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 4));
            float.TryParse(valueString, out valueColor.g);
            GUILayout.Label("b: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 4));
            float.TryParse(valueString, out valueColor.b);
            GUILayout.Label("a: ");
            valueString = EditorGUILayout.TextField(valueString, GUILayout.Width(fieldWidth / 4));
            float.TryParse(valueString, out valueColor.a);
        }
        
        #endregion
    }
    enum VariableTypes
    {
        String,
        Integer,
        Float,
        Boolean,
        Vector2,
        Vector3,
        Vector4,
        Quaternion,
        Color
    };
}