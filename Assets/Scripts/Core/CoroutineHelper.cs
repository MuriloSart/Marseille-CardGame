using System.Collections;
using UnityEngine;

public class CoroutineHelper : MonoBehaviour
{
    private static CoroutineHelper instance;

    public static CoroutineHelper Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject helperObject = new GameObject("CoroutineHelper");
                instance = helperObject.AddComponent<CoroutineHelper>();
                GameObject.DontDestroyOnLoad(helperObject);
            }
            return instance;
        }
    }

    public void RunCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
