using System;
using UnityEditor.PackageManager;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public static BaseManager instance;

    public static PoolManager poolManager = new PoolManager();

    public static PoolManager POOL
    {
        get
        {
            return poolManager;
        }

    }


    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
