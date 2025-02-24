using Unity.VisualScripting;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed = 5f;   // 이동 속도
    public float gravity = 9.8f;   // 중력
    private CharacterController controller;
    private Animator animator;
    private Vector3 moveDirection;
    bool isAim = false;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
  
    }

    private void FixedUpdate()
    {
        // 입력 받기
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // 이동 벡터 설정
        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        // speed 값 즉각 반영 (키를 누르는 즉시 애니메이션 전환됨)
        float speed = move.magnitude;

        bool isMoving = move.magnitude > 0;
        animator.SetBool("isMoving", isMoving);

        //@TK(25.02.24)
        animator.SetFloat("FactorX", moveX);
        animator.SetFloat("FactorZ", moveZ);


        // 이동 중이면 방향을 변경
        //여기서 뒤로 가는 경우 방향을 변경하지 않도록 해줘야됨 ,&& Input.GetKeyDown(KeyCode.W) 
        //if (isMoving )
        //{
        //    transform.forward = move;
        //}

        //누른 방향으로 회전2

        //if (!(moveX == 0 && moveZ == 0)) {
        //    //이동과 회전을 같이 처리
        //    transform.position += move * speed * Time.deltaTime;
        //    //회전하는 부분
        //    transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(move),Time.deltaTime);
        //}

        if (Input.GetMouseButton(1))
        {
            isAim = true;
            animator.SetBool("isAim", isAim);
        }
        else {
            isAim = false;
            animator.SetBool("isAim", isAim);
        }


            // 중력 적용
            if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else
        {
            moveDirection.y = 0; // 바닥에 닿으면 중력 초기화
        }

        // 이동 처리
        moveDirection = move * moveSpeed;
        controller.Move(moveDirection * Time.deltaTime);
    }

}
