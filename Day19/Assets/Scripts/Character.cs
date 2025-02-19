using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    Animator animator;

    public double hp;
    public double atk;
    public float atkSpeed;

    protected float atkRange = 3.0f; // ���ݹ���
    protected float targetRange = 5.0f;  // Ÿ�ٿ� ���� ����

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void SetMotionChange(string motionName, bool param)
    {
        animator.SetBool(motionName, param);
    }

    //�ִϸ��̼� �̺�Ʈ�� ȣ���� �Լ�
    protected virtual void Shoot() {
        Debug.Log("aaaaa");
    }


    protected Transform target;


    //Ÿ���� ã�� ���
    protected void TargetSearch<T>(T[] targets) where T : Component
    {
        var units = targets;

        Transform closet = null;

        float maxDistance = targetRange;

        //Ÿ�� ��ü�� ������� �Ÿ� üũ
        foreach (var unit in units) { 
            //������ �Ÿ� üũ
            float distance = Vector3.Distance(transform.position, unit.transform.position);
            //Ÿ�� �Ÿ����� ������ ���� ����� ��
            if (distance < maxDistance) { 
                closet = unit.transform;
                maxDistance = distance;
            }
            //Ÿ�� ����
            target = closet;

            if (target != null) { 
                transform.LookAt(target.position);
            }

        }
    }

}
