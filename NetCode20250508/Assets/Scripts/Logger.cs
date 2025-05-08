﻿using System;
using System.Diagnostics;
using UnityEngine;

using Debug = UnityEngine.Debug;

public static class Logger
{
    [Conditional("DEV_VER")]
    //info
    public static void Info(string message)
    {
        Debug.LogFormat("[{0}]  {1}",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message);
    }

    [Conditional("DEV_VER")]

    //warning
    public static void Warning(string message)
    {
        Debug.LogWarningFormat("[{0}]  {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message);
    }

    //error
    public static void Error(string message)
    {
        Debug.LogErrorFormat("[{0}]  {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message);
    }
}

