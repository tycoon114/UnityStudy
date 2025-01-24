using System;
using UnityEngine;


//플레이어 이동(리지드바디)

//해당 기능을 통해 이 스크립트를 컴포넌트로서 사용할 경우 해당 컴포넌트를 요구하게 됩니다
// 해당 컴포넌트가 없는 오브젝트에 적용할 경우 자동으로 생성
//이 스크립트를 연결한 상태라면, 대상 컴포넌트 삭제 불가  

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoveMnet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public float speed = 5.0f;

    public double jumpForce = 3.5;

    public bool isJump = false;

    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!isJump)
            {
                isJump = true;
                rigid.AddForce(Vector3.up * (float)jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 velocity = new Vector3(x, y, 0) * speed * Time.deltaTime;

        transform.position += velocity;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    { if (collision.gameObject.tag == "Finish")
            Debug.Log("goal");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 7)
        {
            isJump = false;
        }
        Debug.Log("t");
    }

 


}
