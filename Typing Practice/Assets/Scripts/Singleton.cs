using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
{
    public bool dontDestroyOnLoad;

    private static T instance;

    public static T Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = GetComponent<T>();
    }

    private void OnDestroy()
    {
        instance = default(T);
    }
}
