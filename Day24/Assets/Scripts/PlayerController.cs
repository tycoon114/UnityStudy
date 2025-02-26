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


        //물체의 이동 공식 - 동속 운동
        // P = P0 + vt
        // P(미래의 위치) = P0(현재의 위치) + V(속도)T(시간)
        //등가속도 운동
        //V = V0 + AT
        // 속도 = 현재속도 + 가속도(A)시간(T)
        

    }
}
