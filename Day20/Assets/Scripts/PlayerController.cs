using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    Rigidbody2D rBody;
    float axisH = 0.0f;
    public float speed = 3.0f;

    public float jump = 9.0f;
    public LayerMask groundLayer;
    bool goJump = false;
    bool onGround = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal");

        if (axisH > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);

        }
        else if (axisH < 0.0f)
        {
            //백터가 -로 잡히게 되면 좌우 반전
            transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }


    }

    private void FixedUpdate()
    {
        // 지정한 두 점을 연결하는 가상의 선에 게임 오브젝트가 접촉하는지 조사하여 T,F 로 리턴하는 함수
        //up은 (0,1,0)
        //현재 플레이어의 피벗은 bottom
        onGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 0.1f), groundLayer);

        //지면위에 있거나 속도가 0이 아닌 경우
        if (onGround || axisH != 0)
        {
            rBody.linearVelocity = new Vector2(speed * axisH, rBody.linearVelocityY);
        }

        //지면 위에서 점프키 누를 시
        if (onGround && goJump)
        {
            //플레이어가 가진 점프 수치만큼 백터 설계
            Vector2 jumpPw = new Vector2(0, jump);
            //해당 위치로 힘을 가함
            rBody.AddForce(jumpPw, ForceMode2D.Impulse);
            goJump = false;
        }

    }


    private void Jump()
    {
        goJump = true;
    }
}
