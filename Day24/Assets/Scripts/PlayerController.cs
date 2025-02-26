using UnityEngine;

public class PlayerController : MonoBehaviour
{




    public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, v, 0);


        transform.position += dir * speed * Time.deltaTime;


        //��ü�� �̵� ���� - ���� �
        // P = P0 + vt
        // P(�̷��� ��ġ) = P0(������ ��ġ) + V(�ӵ�)T(�ð�)
        //��ӵ� �
        //V = V0 + AT
        // �ӵ� = ����ӵ� + ���ӵ�(A)�ð�(T)
        

    }
}
