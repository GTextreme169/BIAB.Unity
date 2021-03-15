using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BIAB.Other.Hidden
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}