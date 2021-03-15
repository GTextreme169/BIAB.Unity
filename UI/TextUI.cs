using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BIAB.DataTypes;

public class TextUI : MonoBehaviour
{
    private UnityEngine.UI.Text unityTextComponent;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        unityTextComponent = GetComponent<UnityEngine.UI.Text>();
    }

    [Sirenix.OdinInspector.Button]
    public void Test()
    {
        sString textObject = "Start";
        Assign(ref textObject);
        textObject.variable = "s";
    }

    public void Assign(ref sString text)
    {
        text.OnStringChange += OnVariableChange;
        OnVariableChange(text);
    }

    private void OnVariableChange(string text)
    {
        unityTextComponent.text = text;
    }
}
