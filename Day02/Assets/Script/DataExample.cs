using System;
using UnityEngine;

[Flags]
public enum DAY { 
    None = 0,
    ��= 1 << 0,
    �� = 1<<1,
    ȭ = 1 << 2,
    �� = 1 << 3,
    �� = 1 << 4,
    �� = 1 << 5, 
    �� = 1 << 6
}

public enum JOB
{
    ��,��,��,��,��
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
