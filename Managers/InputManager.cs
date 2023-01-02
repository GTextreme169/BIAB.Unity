using System.Collections;
using System.Collections.Generic;
using BIAB.Unity.Other;
using UnityEngine;

namespace BIAB.Unity
{
    public class InputManager : MonoBehaviour
    {
        Dictionary<string, KeyCode> buttons;
        Dictionary<string, string> axis;

        private static InputManager main;

        private void OnEnable()
        { // Reloads the buttons etc
            if (main == null)
            {
                main = this;
            }
            if (main != this)
                Destroy(this);
            buttons = ExtendedPrefs.GetSerializedObject<Dictionary<string, KeyCode>>("Input_Buttons", new Dictionary<string, KeyCode>());
            axis = ExtendedPrefs.GetSerializedObject<Dictionary<string, string>>("Input_Axis", new Dictionary<string, string>());
        }

        private void _Save()
        {
            ExtendedPrefs.SetSerializedObject<Dictionary<string, KeyCode>>("Input_Buttons", buttons);
            ExtendedPrefs.SetSerializedObject<Dictionary<string, string>>("Input_Axis", axis);
        }

        private void _SetAxisValue(string axisName, string value)
        {
            if (axis.ContainsKey(axisName))
            {
                axis[axisName] = value;
            }
            else
            {
                axis.Add(axisName, value);
            }
        }
        private string _GetAxisValue(string axisName)
        {
            if (axis.ContainsKey(axisName))
            {
                return axis[axisName];
            }
            else
            {
                return "None";
            }
        }

        private void _SetButton(string buttonName, KeyCode value)
        {
            if(buttons.ContainsKey(buttonName))
            {
                buttons[buttonName] = value;
            }
            else
            {
                buttons.Add(buttonName, value);
            }
        }
        private string _GetButtonName(string buttonName)
        {
            if (buttons.ContainsKey(buttonName))
            {
                return buttons[buttonName].ToString();
            }
            else
            {
                return KeyCode.None.ToString();
            }
        }
        private KeyCode _GetButtonValue(string buttonName)
        {
            if (buttons.ContainsKey(buttonName))
            {
                return buttons[buttonName];
            }
            else
            {
                return KeyCode.None;
            }
        }

        private bool _GetButtonUp(string buttonName)
        {
            if (buttons.ContainsKey(buttonName))
            {
                return Input.GetKeyUp(buttons[buttonName]);
            }

            return false;
        }
        private bool _GetButtonDown(string buttonName)
        {
            if (buttons.ContainsKey(buttonName))
            {
                return Input.GetKeyDown(buttons[buttonName]);
            }

            return false;
        }
        private bool _GetButton(string buttonName)
        {
            if (buttons.ContainsKey(buttonName))
            {
                return Input.GetKey(buttons[buttonName]);
            }

            return false;
        }
        private float _GetAxis(string axisName)
        {
            if (axis.ContainsKey(axisName))
            {
                return Input.GetAxis(axis[axisName]);
            }

            return 0f;
        }
        private float _GetAxisRaw(string axisName)
        {
            if (axis.ContainsKey(axisName))
            {
                return Input.GetAxisRaw(axis[axisName]);
            }

            return 0f;
        }

        // Static Links
        public static void Save()
        {
            main._Save();
        }

        public static void SetAxisValue(string axisName, string value)
        {
            main._SetAxisValue(axisName, value);
        }
        public static string GetAxisValue(string axisName)
        {
            return main._GetAxisValue(axisName);
        }

        public static void SetButtonName(string buttonName, KeyCode value)
        {
            main._SetButton(buttonName, value);
        }
        public static string GetButtonName(string buttonName)
        {
            return main._GetButtonName(buttonName);
        }
        public static KeyCode GetButtonValue(string buttonName)
        {
            return main._GetButtonValue(buttonName);
        }

        public static bool GetButtonUp(string buttonName)
        {
            return main._GetButtonUp(buttonName);
        }
        public static bool GetButtonDown(string buttonName)
        {
            return main._GetButtonDown(buttonName);
        }
        public static bool GetButton(string buttonName)
        {
            return main._GetButton(buttonName);
        }
        public static float GetAxis(string axisName)
        {
            return main._GetAxis(axisName);
        }
        public static float GetAxisRaw(string axisName)
        {
            return main._GetAxisRaw(axisName);
        }

    }
}