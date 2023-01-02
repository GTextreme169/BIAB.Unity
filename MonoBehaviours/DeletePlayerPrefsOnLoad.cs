using UnityEngine;

namespace BIAB.Unity.MonoBehaviours
{
    public class DeletePlayerPrefsOnLoad : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        {
            PlayerPrefs.DeleteAll();
        }

    }
}
