using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    private static bool _isApplicationQuitting;

    public static T Ins
    {
        get
        {
            if (_isApplicationQuitting)
                return null;

            if (_instance != null)
                return _instance;

            _instance = FindObjectOfType<T>();
            if (_instance != null)
                return _instance;

            var obj = new GameObject { name = typeof(T).Name };
            _instance = obj.AddComponent<T>();
            return _instance;
        }
    }

    public virtual void Touch() { }

    protected virtual void OnApplicationQuit()
    {
        _isApplicationQuitting = true;
    }
    protected virtual void Awake()
    {
        _instance = this as T;
    }
}
