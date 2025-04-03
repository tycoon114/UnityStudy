using Unity.Cinemachine;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CineMachineTest : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("CinemachineCore");
        CinemachineCore.GetInputAxis = clickControl;
    }

    public float clickControl(string axis)
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("aaassdd");

            return UnityEngine.Input.GetAxis(axis);
        }
        return 0;
    }
}
