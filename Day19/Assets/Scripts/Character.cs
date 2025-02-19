using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    Animator animator;

    public double hp;
    public double atk;
    public float atkSpeed;

    protected float atkRange = 3.0f; // 공격범위
    protected float targetRange = 5.0f;  // 타겟에 대한 범위

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void SetMotionChange(string motionName, bool param)
    {
        animator.SetBool(motionName, param);
    }

    //애니메이션 이벤트가 호출할 함수
    protected virtual void Shoot() {
        Debug.Log("aaaaa");
    }


    protected Transform target;


    //타겟을 찾는 기능
    protected void TargetSearch<T>(T[] targets) where T : Component
    {
        var units = targets;

        Transform closet = null;

        float maxDistance = targetRange;

        //타겟 전체를 대상으로 거리 체크
        foreach (var unit in units) { 
            //상대와의 거리 체크
            float distance = Vector3.Distance(transform.position, unit.transform.position);
            //타겟 거리보다 작으면 가장 가까운 값
            if (distance < maxDistance) { 
                closet = unit.transform;
                maxDistance = distance;
            }
            //타겟 적용
            target = closet;

            if (target != null) { 
                transform.LookAt(target.position);
            }

        }
    }

}
