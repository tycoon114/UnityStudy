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

    public static string state = "playing";  // ������ ����(�÷��� ��)


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
            //���Ͱ� -�� ������ �Ǹ� �¿� ����
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


        // ������ �� ���� �����ϴ� ������ ���� ���� ������Ʈ�� �����ϴ��� �����Ͽ� T,F �� �����ϴ� �Լ�
        //up�� (0,1,0)
        //���� �÷��̾��� �ǹ��� bottom
        onGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 0.1f), groundLayer);

        //�������� �ְų� �ӵ��� 0�� �ƴ� ���
        if (onGround || axisH != 0)
        {
            rBody.linearVelocity = new Vector2(speed * axisH, rBody.linearVelocityY);
        }

        //���� ������ ����Ű ���� ��
        if (onGround && goJump)
        {
            //�÷��̾ ���� ���� ��ġ��ŭ ���� ����
            Vector2 jumpPw = new Vector2(0, jump);
            //�ش� ��ġ�� ���� ����
            rBody.AddForce(jumpPw, ForceMode2D.Impulse);
            goJump = false;
        }


        if (onGround)
        {
            if (axisH == 0)
            {

                //�ش� enum�� �ִ� �� ���� �̸��� ����
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

        //�ִϸ��̼� ����� ���
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

        //�÷��̾��� ĸ���ݶ��̴� ��Ȱ��ȭ -> ���̻��� �浹 ��Ȱ��ȭ
        GetComponent<CapsuleCollider2D>().enabled = false;
        //���� ��¦ �ٴ� ����
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
