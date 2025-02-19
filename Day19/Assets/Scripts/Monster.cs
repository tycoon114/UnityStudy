using System;
using UnityEngine;


public class Monster : Character
{
    public float monsterSpeed;

    public float rate = 0.5f;


    protected override void Start()
    {
        base.Start();
    }

    //action �׽�Ʈ
    public void MonsterSample()
    {
        Debug.Log("����");
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
}
