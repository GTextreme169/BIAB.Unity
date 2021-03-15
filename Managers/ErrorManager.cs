using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BIAB
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