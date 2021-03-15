using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;
using BIAB.DataTypes;
using UnityEngine;

public static class GUIFunctions
{
    /// <summary>
    /// Toggle Using Buttons
    /// </summary>
    /// <param name="boolean">Variable To Toggle</param>
    /// <param name="Label">What is Displayed On The Button</param>
	public static void Toggle(ref bool boolean, string Label)
    {
        Color col = GUI.color;
        if (boolean == false)
        {
            GUI.color = Color.red;
        }
        else
        {
            GUI.color = Color.green;
        }
        if (GUILayout.Button(Label))
        {
            boolean = !boolean;
        }
        GUI.color = col;
    }
    /// <summary>
    /// Toggle Using Buttons
    /// </summary>
    /// <param name="boolean">Variable To Toggle</param>
    /// <param name="Label">What is Displayed On The Button</param>
    /// <param name="Option">GUILayout Option</param>
    public static void Toggle(ref bool boolean, string Label, GUILayoutOption Option)
    {
        Color col = GUI.color;
        if (boolean == false)
        {
            GUI.color = Color.red;
        }
        else
        {
            GUI.color = Color.green;
        }
        if (GUILayout.Button(Label, Option))
        {
            boolean = !boolean;
        }
        GUI.color = col;
    }
    /// <summary>
    /// Toggle Using Buttons
    /// </summary>
    /// <param name="boolean">Variable To Toggle</param>
    /// <param name="Label">What is Displayed On The Button</param>
    /// <param name="Options">GUILayout Options</param>
    public static void Toggle(ref bool boolean, string Label, GUILayoutOption[] Options)
    {
        Color col = GUI.color;
        if (boolean == false)
        {
            GUI.color = Color.red;
        }
        else
        {
            GUI.color = Color.green;
        }
        if (GUILayout.Button(Label, Options))
        {
            boolean = !boolean;
        }
        GUI.color = col;
    }
    public static int Toggle(int data, string Label)
    {
        bool boolean = (data == 1);
        Color col = GUI.color;
        if (boolean == false)
        {
            GUI.color = Color.red;
        }
        else
        {
            GUI.color = Color.green;
        }
        if (GUILayout.Button(Label))
        {
            boolean = !boolean;
        }
        GUI.color = col;
        return (boolean) ? 1 : 0;
    }
    public static bool Toggle(bool boolean, string Label)
    {
        Color col = GUI.color;
        if (boolean == false)
        {
            GUI.color = Color.red;
        }
        else
        {
            GUI.color = Color.green;
        }
        if (GUILayout.Button(Label))
        {
            boolean = !boolean;
        }
        GUI.color = col;
        return boolean;
    }
    public static int ToggleI(bool boolean, string Label)
    {
        Color col = GUI.color;
        if (boolean == false)
        {
            GUI.color = Color.red;
        }
        else
        {
            GUI.color = Color.green;
        }
        if (GUILayout.Button(Label))
        {
            boolean = !boolean;
        }
        GUI.color = col;
        return (boolean) ? 1 : 0;
    }
    public static void Toggle(string playerpref, string Label)
    {
        bool boolean = (PlayerPrefs.GetInt(playerpref) == 1);
        Color col = GUI.color;
        if (boolean == false)
        {
            GUI.color = Color.red;
        }
        else
        {
            GUI.color = Color.green;
        }
        if (GUILayout.Button(Label))
        {
            boolean = !boolean;
        }
        GUI.color = col;
        PlayerPrefs.SetInt(playerpref, (boolean) ? 1 : 0);
    }
    public static void Toggle(string playerpref, int defaultP, string Label)
    {
        bool boolean = (PlayerPrefs.GetInt(playerpref, defaultP) == 1);
        Color col = GUI.color;
        if (boolean == false)
        {
            GUI.color = Color.red;
        }
        else
        {
            GUI.color = Color.green;
        }
        if (GUILayout.Button(Label))
        {
            boolean = !boolean;
        }
        GUI.color = col;
        PlayerPrefs.SetInt(playerpref, (boolean) ? 1 : 0);
    }

    /// <summary>
    /// Generic Slider With Label
    /// </summary>
    /// <param name="number">Number</param>
    /// <param name="max">Maximum</param>
    /// <param name="min">Minimum</param>
    /// <param name="Label">Label</param>
    public static void HSlider(ref float number, Range range, string Label)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(Label + " (" + number + "):");
        number = GUILayout.HorizontalSlider(number, range.max, range.min);
        GUILayout.EndHorizontal();
    }
    public static void HSlider(ref int number, Range range, string Label)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(Label + " (" + number + "):");
        number = Mathf.RoundToInt(GUILayout.HorizontalSlider((float)number, range.max, range.min));
        GUILayout.EndHorizontal();
    }

    /// <summary>
    /// Generic Slider With Label Rounded
    /// </summary>
    /// <param name="number">Number</param>
    /// <param name="max">Maximum</param>
    /// <param name="min">Minimum</param>
    /// <param name="Label">Label</param>
    public static void HSliderRound(ref float number, Range range, string Label)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(Label + " (" + number + "):");
        number = Mathf.Round(GUILayout.HorizontalSlider(number, range.max, range.min));
        GUILayout.EndHorizontal();
    }

    /// <summary>
    /// Generic Float/Int Label and Buttons
    /// </summary>
    /// <param name="number">Number</param>
    /// <param name="max">Maximum</param>
    /// <param name="min">Minimum</param>
    /// <param name="Label">Label</param>
    public static void HButtons(ref int number, Range range, int increment, string Label, bool tip = true)
    {
        HButtons(ref number, range, increment, Label, tip);
    }
    public static void HButtons(ref float number, Range range, float increment, string Label, bool tip = true)
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("<")) number += increment;
        GUILayout.Button(Label + " (" + number + ")");
        if (GUILayout.Button(">")) number -= increment;
        GUILayout.EndHorizontal();

        number = WrapLockNumber(number,range, tip);
    }

    public static void HButtonsEnum(ref int number, Range range, int increment, string Label, bool tip, Enum en)
    {
        string[] data = (Enum.GetNames(en.GetType()));

        if (range.max > data.Length-1) range.max = data.Length-1;
        if (range.min< 0) range.min = 0;
        number = (int)WrapLockNumber(number, range, tip);

        int pretest = number;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("<")) number += increment;
        GUILayout.BeginVertical();
        GUILayout.Box(Label + "\n" + data[pretest]);
        GUILayout.EndVertical();
        if (GUILayout.Button(">")) number -= increment;
        GUILayout.EndHorizontal();
        
    }
    public static void HButtonsEnum(ref int number, string Label, bool tip, Enum en)
    {
        HButtonsEnum(ref number, new Range(int.MaxValue, 0), 1, Label, tip, en);
    }
    public static void HButtonsKeyCode(ref KeyCode code, string Label, bool tip)
    {
        int number = (int)code;
        string[] data = (Enum.GetNames(new KeyCode().GetType()));

        int max = data.Length - 1;
        int min = 0;
        number = (int)WrapLockNumber(number, new Range(max,0), tip);

        int pretest = number;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("<")) number += 1;
        GUILayout.BeginVertical();
        GUILayout.Box(Label + "\n" + (KeyCode)pretest);
        GUILayout.EndVertical();
        if (GUILayout.Button(">")) number -= 1;
        GUILayout.EndHorizontal();

        code = (KeyCode)number;
    }

    public static void HButtonsNum(ref int number, Range range, int increment, string Label, bool tip)
    {
        number = HButtonsNum(number, range, increment, Label, tip);
    }
    public static int HButtonsNum(int number, Range range, int increment, string Label, bool tip)
    {
        number = (int)WrapLockNumber(number, range, tip);

        int pretest = number;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("<")) number -= increment;
        GUILayout.BeginVertical();
        GUILayout.Box(Label + "\n" + pretest);
        GUILayout.EndVertical();
        if (GUILayout.Button(">")) number += increment;
        GUILayout.EndHorizontal();


        return number;
    }

    public static float WrapLockNumber(float number, Range range,  bool wrap)
    {
        if (number >  range.max && wrap) number = (int)range.min;
        if (number >  range.max && !wrap) number =  (int)range.max;
        if (number <  range.min && wrap) number =  (int)range.max;
        if (number <  range.min && !wrap) number =  (int)range.min;
        return number;
    }

    public static void BeginToggleList(ref bool toggle, ref Vector2 vec2, string label)
    {
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.Label(label, GUILayout.Width(3*(Screen.width / 5)));
        Toggle(ref toggle, "Show");
        GUILayout.EndHorizontal();
        if (toggle)
            vec2 = GUILayout.BeginScrollView(vec2);
    }
    public static void EndToggleList(bool toggle)
    {
       if(toggle) GUILayout.EndScrollView();

        GUILayout.EndVertical();
    }

    public static void BeginHorizontal()
    {
        GUILayout.BeginHorizontal();
    }
    public static void EndHorizontal()
    {
        GUILayout.EndHorizontal();
    }

    public static void BeginVertical()
    {
        GUILayout.BeginVertical();
    }
    public static void EndVertical()
    {
        GUILayout.EndVertical();
    }

    public static void ProgressBar(float Progress, string Label)
    {
        GUI.skin.box.normal.background = new Texture2D(1, 1);
        GUI.backgroundColor = Color.gray;
        GUILayout.Box("");

        GUI.contentColor = Color.black;
        GUI.backgroundColor = Color.green;
        Rect rect = GUILayoutUtility.GetLastRect();
        GUI.Box(new Rect(rect.x, rect.y, rect.width * Progress, rect.height), Mathf.RoundToInt(Progress * 100) + "% " + Label);
    }
    public static void ProgressBar(float Progress, string Label, Color BG, Color FG)
    {
        GUI.skin.box.normal.background = new Texture2D(1, 1);
        GUI.backgroundColor = BG;
        GUILayout.Box("");

        GUI.contentColor = Color.black;
        GUI.backgroundColor = FG;
        Rect rect = GUILayoutUtility.GetLastRect();
        GUI.Box(new Rect(rect.x, rect.y, rect.width * Progress, rect.height), Mathf.RoundToInt(Progress * 100) + "% " + Label);
    }
    public static void ProgressBar(float Progress, string Label, Color BG, Color FG, Color CG)
    {
        GUI.skin.box.normal.background = new Texture2D(1, 1);
        GUI.backgroundColor = BG;
        GUILayout.Box("");

        GUI.contentColor = CG;
        GUI.backgroundColor = FG;
        Rect rect = GUILayoutUtility.GetLastRect();
        GUI.Box(new Rect(rect.x, rect.y, rect.width * Progress, rect.height), Mathf.RoundToInt(Progress * 100) + "% " + Label);
    }

    public static void ProgressBar(Rect rect, float Progress, string Label)
    {
        GUI.skin.box.normal.background = new Texture2D(1, 1);
        GUI.backgroundColor = Color.gray;
        GUI.Box(rect, "");

        GUI.contentColor = Color.black;
        GUI.backgroundColor = Color.green;
        GUI.Box(new Rect(rect.x, rect.y, rect.width*Progress, rect.height), Mathf.RoundToInt(Progress * 100) + "% " + Label);
    }
    public static void ProgressBar(Rect rect, float Progress, string Label, Color BG, Color FG)
    {
        GUI.skin.box.normal.background = new Texture2D(1, 1);
        GUI.backgroundColor = BG;
        GUI.Box(rect, "");

        GUI.contentColor = Color.black;
        GUI.backgroundColor = FG;
        GUI.Box(new Rect(rect.x, rect.y, rect.width * Progress, rect.height), Mathf.RoundToInt(Progress * 100) + "% " + Label);
    }
    public static void ProgressBar(Rect rect, float Progress, string Label, Color BG, Color FG, Color CG)
    {
        GUI.skin.box.normal.background = new Texture2D(1, 1);
        GUI.backgroundColor = BG;
        GUI.Box(rect, "");

        GUI.contentColor = CG;
        GUI.backgroundColor = FG;
        GUI.Box(new Rect(rect.x, rect.y, rect.width * Progress, rect.height), Mathf.RoundToInt(Progress * 100) + "% " + Label);
    }

    public static void ColorPicker(ref Color color, bool Alpha = false)
    {
        color = ColorPicker(color, Alpha);
    }
    public static Color ColorPicker(Color color, bool Alpha = false)
    {
        BeginVertical();
        float r = color.r * 255, g = color.g * 255, b = color.b * 255, a = color.a * 255;
        HSliderRound(ref r, new Range(255, 0), "Red: ");
        HSliderRound(ref g, new Range(255, 0), "Green: ");
        HSliderRound(ref b, new Range(255, 0), "Blue: ");
        if (Alpha) HSliderRound(ref a, new Range(255, 0), "Alpha: ");
        EndVertical();
        return new Color(r / 255, g / 255, b / 255);   
    }

    public static void SquareColorPicker(ref Color color, bool Alpha = false)
    {
        BeginHorizontal();
        Color temp = GUI.color;
        GUI.color = color;
        GUILayout.Box(new Texture2D(1, 1));
        GUI.color = temp;
        ColorPicker(ref color, Alpha);
        EndHorizontal();
    }
    public static Color SquareColorPicker(Color color, bool Alpha = false)
    {
        BeginHorizontal();
        Color temp = GUI.color;
        GUI.color = color;
        GUILayout.Box(new Texture2D(1,1));
        GUI.color = temp;

        temp = ColorPicker(color, Alpha);
        EndHorizontal();
        return temp;
    }

    public static Texture GradientTexture;
    public static void GradientColorPicker(ref Color color, bool Alpha = false)
    {
        BeginHorizontal();
        Color temp = GUI.color;
        GUI.color = color;
        GUILayout.Box(GradientTexture);
        GUI.color = temp;
        ColorPicker(ref color, Alpha);
        EndHorizontal();
    }
    public static Color GradientColorPicker(Color color, bool Alpha = false)
    {
        BeginHorizontal();
        Color temp = GUI.color;
        GUI.color = color;
        GUILayout.Box(GradientTexture);
        GUI.color = temp;

        temp = ColorPicker(color, Alpha);
        EndHorizontal();
        return temp;
    }

    /*
    public static void TimerLabel(Timer timer, string label)
    {
        GUILayout.Label("(" + (int)timer.passedTime + ")" + label);
    }
    public static bool TimerButton(Timer timer, string label)
    {
        return GUILayout.Button("(" + (int)timer.passedTime + ") " + label);
    }
    */
    public static Texture2D EditTexture(Texture2D texture)
    {
        return texture;
    }
    public static void EditTexture(ref Texture2D texture)
    {
        
    }
}
