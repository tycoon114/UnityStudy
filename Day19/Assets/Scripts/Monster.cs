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

    //action 테스트
    public void MonsterSample()
    {
        Debug.Log("생성");
    }

    // Update is called once per frame
    void Update()
    {
        //영점 기준으로 시선 변경
        transform.LookAt(Vector3.zero);

        //간격 설정
        float targetDistance = Vector3.Distance(transform.position, Vector3.zero);

        if (targetDistance <= rate)
        {
            SetMotionChange("isMOVE", false);
        }
        else
        {
            SetMotionChange("isMOVE", true);
        }
        //영점으로, 몬스터의 속도만큼 앞으로 이동
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * monsterSpeed);
    }
}
