using UnityEngine;

public class CircleMove : MonoBehaviour
{

    public GameObject Circle;

    Vector3 pos = new Vector3(5, -4, 0);


    void Update()
    {
        //Circle.transform.position = Vector3.Lerp(Circle.transform.position, pos, Time.deltaTime);
        //0�� �Է��� ��� �������� �ʰ�, 1�� �ִ�ġ�̴�.

        // ������ �ӵ��� ��ǥ���� �̵�
        //Circle.transform.position = Vector3.MoveTowards(Circle.transform.position,pos,Time.deltaTime);


        Circle.transform.position = Vector3.Slerp(Circle.transform.position,pos,0.05f);

    }
}
