using UnityEngine;

public class CircleMove : MonoBehaviour
{

    public GameObject Circle;

    Vector3 pos = new Vector3(5, -4, 0);


    void Update()
    {
        //Circle.transform.position = Vector3.Lerp(Circle.transform.position, pos, Time.deltaTime);
        //0을 입력할 경우 움직이지 않고, 1이 최대치이다.

        // 일정한 속도로 목표까지 이동
        //Circle.transform.position = Vector3.MoveTowards(Circle.transform.position,pos,Time.deltaTime);


        Circle.transform.position = Vector3.Slerp(Circle.transform.position,pos,0.05f);

    }
}
