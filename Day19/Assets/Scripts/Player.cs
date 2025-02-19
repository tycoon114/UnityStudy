using UnityEngine;

public class Player : Character
{

    Vector3 startPos;
    Quaternion rotation;
    protected override void Start()
    {
        base.Start();

        //시작 값 설정 
        startPos = transform.position;
        rotation = transform.rotation;

    }

    void Update()
    {
        if (target == null)
        {
            //가까운 타겟 조사
            TargetSearch(Spawner.monsterList.ToArray());
            //To array를 통해 리스트를 어레이로 바꿔준다

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

        //타겟 범위보다 작으면서 공격 범위 보다 높은 경우
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
