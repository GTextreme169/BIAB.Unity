using BIAB.Unity.Handlers;
using UnityEngine;

namespace BIAB.Unity.Managers
{
    public class ErrorManager : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
        private void OnEnable()
        {
            Application.logMessageReceived += LogError;
        }

        private void OnDisable()
        {
            Application.logMessageReceived -= LogError;
        }

        public virtual void LogError(string condition, string stackTrace, LogType type)
        {
            ConsoleHandler.LogError(condition, stackTrace, type);
        }
    }
}