using System;
using UnityEngine;

[Flags]
public enum DAY { 
    None = 0,
    일= 1 << 0,
    월 = 1<<1,
    화 = 1 << 2,
    수 = 1 << 3,
    목 = 1 << 4,
    금 = 1 << 5, 
    토 = 1 << 6
}

public enum JOB
{
    가,나,다,라,마
}


public class DataExample : MonoBehaviour
{
    private string[] schedule;
    public DAY workDay;
    public JOB job;

    private void Start()
    {
        //Debug.Log($"")

        for (int i = 0; i < schedule.Length; i++)
        {
            Debug.Log(schedule[i]);

        }

        Debug.Log(workDay);
        Debug.Log(job);

    }

}
