/* Made By: Trevin Pointer
 * Description: A simple Extended PlayerPref Editor Addition
 * Notes: Will be Overwrite PlayerPref Editor if it is installed
 * Install: Place script under Assets/Editor Folder
 */

using BIAB.Unity.Other;
using UnityEngine;
using UnityEditor;

namespace BIAB.Unity.Editor
{
    public class ExtendedPlayerPrefsWindow : EditorWindow
    {
        private string _menu = "";
        private int _fieldWidth = 150;

        // Add/Remove Pref
        private int _variableTypeInt = 0;
        private string _variableName = "";
        private bool _valueBool = false;
        private string _valueString = "";
        private int _valueInt = 0;
        private float _valueFloat = 0;
        private Vector2 _valueVector2 = new Vector2();
        private Vector3 _valueVector3 = new Vector3();
        private Vector4 _valueVector4 = new Vector4();
        private Quaternion _valueQuat = new Quaternion();
        private Color _valueColor = new Color();
    #region Toolbar
        [MenuItem("Tools/BIAB/PlayerPrefs/Reset")]
        static void ResetPP()
        {
            // Get existing open window or if none, make a new one:
            ExtendedPlayerPrefsWindow window = (ExtendedPlayerPrefsWindow)EditorWindow.GetWindow(typeof(ExtendedPlayerPrefsWindow));
            window.Show();
            window._menu = "reset";
        }
        [MenuItem("Tools/BIAB/PlayerPrefs/Add")]
        static void AddPP()
        {
            ExtendedPlayerPrefsWindow window = (ExtendedPlayerPrefsWindow)EditorWindow.GetWindow(typeof(ExtendedPlayerPrefsWindow));
            window.Show();
            window._menu = "add";
        }
        [MenuItem("Tools/BIAB/PlayerPrefs/Edit")]
        static void EditPP()
        {
            ExtendedPlayerPrefsWindow window = (ExtendedPlayerPrefsWindow)EditorWindow.GetWindow(typeof(ExtendedPlayerPrefsWindow));
            window.Show();
            window._menu = "edit";
        }
        [MenuItem("Tools/BIAB/PlayerPrefs/Remove")]
        static void RemovePP()
        {
            ExtendedPlayerPrefsWindow window = (ExtendedPlayerPrefsWindow)EditorWindow.GetWindow(typeof(ExtendedPlayerPrefsWindow));
            window.Show();
            window._menu = "remove";
        }
        [MenuItem("Tools/BIAB/Help/Wiki")]
        static void OpenWiki()
        {
            Application.OpenURL("https://github.com/GTextreme169/BIAB.Unity/wiki");  
        }
        [MenuItem("Tools/BIAB/Help/GitHub")]
        static void OpenGithub()
        {
            Application.OpenURL("https://github.com/GTextreme169/BIAB.Unity");  
        }

        #endregion
        
        
        void OnGUI()
        {
            switch (_menu)
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
                    ExtendedPrefs.DeleteString(_variableName);
                    break;
                case VariableTypes.Integer:
                    ExtendedPrefs.DeleteInt(_variableName);
                    break;
                case VariableTypes.Float:
                    ExtendedPrefs.DeleteFloat(_variableName);
                    break;
                case VariableTypes.Boolean:
                    ExtendedPrefs.DeleteBool(_variableName);
                    break;
                case VariableTypes.Vector2:
                    ExtendedPrefs.DeleteVector2(_variableName);
                    break;
                case VariableTypes.Vector3:
                    ExtendedPrefs.DeleteVector3(_variableName);
                    break;
                case VariableTypes.Vector4:
                    ExtendedPrefs.DeleteVector4(_variableName);
                    break;
                case VariableTypes.Quaternion:
                    ExtendedPrefs.DeleteQuaternion(_variableName);
                    break;
                case VariableTypes.Color:
                    ExtendedPrefs.DeleteColor(_variableName);
                    break;
            }
        }
        
        void SetVariable(VariableTypes variableType)
            {
                switch (variableType)
                {
                    case VariableTypes.String:
                        ExtendedPrefs.SetString(_variableName, _valueString);
                        break;
                    case VariableTypes.Integer:
                        ExtendedPrefs.SetInt(_variableName, _valueInt);
                        break;
                    case VariableTypes.Float:
                        ExtendedPrefs.SetFloat(_variableName, _valueFloat);
                        break;
                    case VariableTypes.Boolean:
                        ExtendedPrefs.SetBool(_variableName, _valueBool);
                        break;
                    case VariableTypes.Vector2:
                        ExtendedPrefs.SetVector2(_variableName, _valueVector2);
                        break;
                    case VariableTypes.Vector3:
                        ExtendedPrefs.SetVector3(_variableName, _valueVector3);
                        break;
                    case VariableTypes.Vector4:
                        ExtendedPrefs.SetVector4(_variableName, _valueVector4);
                        break;
                    case VariableTypes.Quaternion:
                        ExtendedPrefs.SetQuaternion(_variableName, _valueQuat);
                        break;
                    case VariableTypes.Color:
                        ExtendedPrefs.SetColor(_variableName, _valueColor);
                        break;
                }
            }

        void GetVariable(VariableTypes variableType)
        {
            switch (variableType)
            {
                case VariableTypes.String:
                    _valueString = ExtendedPrefs.GetString(_variableName, _valueString);
                    break;
                case VariableTypes.Integer:
                    _valueInt = ExtendedPrefs.GetInt(_variableName, _valueInt);
                    break;
                case VariableTypes.Float:
                    _valueFloat = ExtendedPrefs.GetFloat(_variableName, _valueFloat);
                    break;
                case VariableTypes.Boolean:
                    _valueBool = ExtendedPrefs.GetBool(_variableName, _valueBool);
                    break;
                case VariableTypes.Vector2:
                    _valueVector2 = ExtendedPrefs.GetVector2(_variableName, _valueVector2);
                    break;
                case VariableTypes.Vector3:
                    _valueVector3 = ExtendedPrefs.GetVector3(_variableName, _valueVector3);
                    break;
                case VariableTypes.Vector4:
                    _valueVector4 = ExtendedPrefs.GetVector4(_variableName, _valueVector4);
                    break;
                case VariableTypes.Quaternion:
                    _valueQuat = ExtendedPrefs.GetQuaternion(_variableName, _valueQuat);
                    break;
                case VariableTypes.Color:
                    _valueColor = ExtendedPrefs.GetColor(_variableName, _valueColor);
                    break;
            }
        }

        VariableTypes TypeFieldLogic()
        {
            GUILayout.BeginHorizontal();
            
            if (GUILayout.Button(((VariableTypes)_variableTypeInt).ToString()))
                _variableTypeInt++;
            
            // No Overflow
            if (_variableTypeInt > 8) _variableTypeInt = 0;
            
            GUILayout.EndHorizontal(); 
            return (VariableTypes)_variableTypeInt;
        }

        void NameField()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Name: ");
            _variableName = EditorGUILayout.TextField(_variableName, GUILayout.Width(_fieldWidth));
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
            _valueBool = EditorGUILayout.Toggle(_valueBool);
        }
        
        void ShowEditString()
        {
            GUILayout.Label("Value: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth));
        }
        void ShowEditInt()
        {
            GUILayout.Label("Value: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth));
            int.TryParse(_valueString, out _valueInt);
            
        }
        void ShowEditFloat()
        {
            GUILayout.Label("Value: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth));
            float.TryParse(_valueString, out _valueFloat);
        }

        void ShowEditVector2()
        {
            GUILayout.Label("x: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 2));
            float.TryParse(_valueString, out _valueVector2.x);
            GUILayout.Label("y: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 2));
            float.TryParse(_valueString, out _valueVector2.y);
            
        }
        void ShowEditVector3()
        {
            GUILayout.Label("x: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 3));
            float.TryParse(_valueString, out _valueVector3.x);
            GUILayout.Label("y: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 3));
            float.TryParse(_valueString, out _valueVector3.y);
            GUILayout.Label("z: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 3));
            float.TryParse(_valueString, out _valueVector3.z);
            
        }
        void ShowEditVector4()
        {
            GUILayout.Label("x: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 4));
            float.TryParse(_valueString, out _valueVector4.x);
            GUILayout.Label("y: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 4));
            float.TryParse(_valueString, out _valueVector4.y);
            GUILayout.Label("z: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 4));
            float.TryParse(_valueString, out _valueVector4.z);
            GUILayout.Label("w: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 4));
            float.TryParse(_valueString, out _valueVector4.w);
        }

        void ShowEditQuaternion()
        {
            GUILayout.Label("x: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 4));
            float.TryParse(_valueString, out _valueQuat.x);
            GUILayout.Label("y: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 4));
            float.TryParse(_valueString, out _valueQuat.y);
            GUILayout.Label("z: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 4));
            float.TryParse(_valueString, out _valueQuat.z);
            GUILayout.Label("w: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 4));
            float.TryParse(_valueString, out _valueQuat.w);
        }
        

        void ShowEditColor()
        {
            GUILayout.Label("r: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 4));
            float.TryParse(_valueString, out _valueColor.r);
            GUILayout.Label("g: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 4));
            float.TryParse(_valueString, out _valueColor.g);
            GUILayout.Label("b: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 4));
            float.TryParse(_valueString, out _valueColor.b);
            GUILayout.Label("a: ");
            _valueString = EditorGUILayout.TextField(_valueString, GUILayout.Width(_fieldWidth / 4));
            float.TryParse(_valueString, out _valueColor.a);
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