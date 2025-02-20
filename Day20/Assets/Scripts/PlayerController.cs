using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public enum ANIME_STATE
    {
        PlayerIdle,
        PlayerClear,
        PlayerGameOver,
        PlayerRun,
        PlayerJump
    }

    Animator animator;
    public string currentState ="";
    public string prevState = "";


    Rigidbody2D rBody;
    float axisH = 0.0f;
    public float speed = 3.0f;

    public float jump = 9.0f;
    public LayerMask groundLayer;
    bool goJump = false;
    bool onGround = false;

    public static string state = "playing";  // 현재의 상태(플레이 중)


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        state = "playing";
    }

    // Update is called once per frame
    void Update()
    {
        if (state != "playing")
        {
            return;
        }


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
        if (state != "playing")
        {
            return;
        }


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


        if (onGround)
        {
            if (axisH == 0)
            {

                //해당 enum에 있는 그 값의 이름을 얻어옴
                currentState = Enum.GetName(typeof(ANIME_STATE), 0);
            }
            else
            {
                currentState = Enum.GetName(typeof(ANIME_STATE), 3);
            }
        }
        else
        {
            currentState = Enum.GetName(typeof(ANIME_STATE), 4);
        }

        //애니메이션 변경된 경우
        if (currentState != prevState)
        {
            prevState = currentState;
            animator.Play(currentState);
        }



    }


    private void Jump()
    {
        goJump = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        else if (collision.gameObject.tag == "Dead")
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        animator.Play(Enum.GetName(typeof(ANIME_STATE), 2));
        state = "gameover";
        GameStop();

        //플레이어의 캡슐콜라이더 비활성화 -> 더이상의 충돌 비활성화
        GetComponent<CapsuleCollider2D>().enabled = false;
        //위로 살짝 뛰는 연출
        rBody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    private void GameStop()
    {
        rBody.linearVelocity = new Vector2(0,0);
    }

    private void Goal()
    {
        animator.Play(Enum.GetName(typeof(ANIME_STATE), 1));
        state = "gameclear";
        GameStop();

    }
}
