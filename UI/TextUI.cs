using BIAB.Unity.Types;
using UnityEngine;

namespace BIAB.Unity.UI
{
    public class TextUI : MonoBehaviour
    {
        private UnityEngine.UI.Text _unityTextComponent;
        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            _unityTextComponent = GetComponent<UnityEngine.UI.Text>();
        }

#if ODIN_INSPECTOR
        [Sirenix.OdinInspector.Button]
        public void Test()
        {
            TrackedString textObject = "Start";
            Assign(ref textObject);
            textObject.Value = "s";
        }
#endif

        public void Assign(ref TrackedString text)
        {
            text.OnStringChange += OnVariableChange;
            OnVariableChange(text);
        }

        private void OnVariableChange(string text)
        {
            _unityTextComponent.text = text;
        }
    }
}
