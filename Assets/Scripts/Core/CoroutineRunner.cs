using UnityEngine;
using System.Collections;

public class CoroutineRunner : MonoBehaviour
{
    private static CoroutineRunner _instance;

    public static CoroutineRunner Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("CoroutineRunner");
                _instance = go.AddComponent<CoroutineRunner>();
            }
            return _instance;
        }
    }

    public Coroutine StartCustomCoroutine(IEnumerator coroutine)
    {
        return StartCoroutine(coroutine);
    }
}
