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

    private void SetMotionChange(string motionName, bool param)
    {
        animator.SetBool(motionName, param);
    }
}
