using System;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class Monster : MonoBehaviour
{
    public float monsterSpeed;

    public float rate = 0.5f;

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //���� �������� �ü� ����
        transform.LookAt(Vector3.zero);

        //���� ����
        float targetDistance = Vector3.Distance(transform.position, Vector3.zero);

        if (targetDistance <= rate)
        {
            SetMotionChange("isMOVE", false);
        }
        else
        {
            SetMotionChange("isMOVE", true);
        }



        //��������, ������ �ӵ���ŭ ������ �̵�
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * monsterSpeed);


    }

    private void SetMotionChange(string motionName, bool param)
    {
        animator.SetBool(motionName, param);
    }
}
