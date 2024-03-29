﻿using UnityEngine;

namespace Source.Core
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        protected static T Instance
        {
            get
            {
                if (_instance is null)
                    _instance = FindObjectOfType<T>() ?? new GameObject(typeof(T).Name).AddComponent<T>();

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance is null)
            {
                _instance = this as T;
                DontDestroyOnLoad(_instance);
            }
            else
                Destroy(gameObject);
        }
    }
}