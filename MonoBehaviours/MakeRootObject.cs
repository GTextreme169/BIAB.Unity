using UnityEngine;

namespace BIAB.Unity.MonoBehaviours
{
    public class MakeRootObject : MonoBehaviour
    {
        void Awake()
        {
            transform.SetParent(null);
        }
    }
}