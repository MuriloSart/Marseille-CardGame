using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;

    public void Awake()
    {
        if (Instance == null)
            Instance = GetComponent<T>();
        else
            Destroy(gameObject);
    }
}

    