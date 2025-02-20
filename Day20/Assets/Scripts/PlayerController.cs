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

    }


    private void Jump()
    {
        goJump = true;
    }
}
