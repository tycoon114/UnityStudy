using UnityEngine;

public class Player : Character
{

    Vector3 startPos;
    Quaternion rotation;
    protected override void Start()
    {
        base.Start();

        //���� �� ���� 
        startPos = transform.position;
        rotation = transform.rotation;

    }

    void Update()
    {
        if (target == null)
        {
            //����� Ÿ�� ����
            TargetSearch(Spawner.monsterList.ToArray());
            //To array�� ���� ����Ʈ�� ��̷� �ٲ��ش�

            float pos = Vector3.Distance(transform.position, startPos);
            if (pos > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * 2.0f);
                transform.LookAt(startPos);
                SetMotionChange("isMOVE", true);

            }
            else
            {
                transform.rotation = rotation;
                SetMotionChange("isMOVE", false);
            }
            return;
        }

        float distance = Vector3.Distance(transform.position,target.position);

        //Ÿ�� �������� �����鼭 ���� ���� ���� ���� ���
        if (distance <= targetRange && distance > atkRange)
        {
            SetMotionChange("isMOVE", true);
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * 2.0f);
        }
        else if (distance <= atkRange) {
            SetMotionChange("isATTACK", true);
        }


    }

}
