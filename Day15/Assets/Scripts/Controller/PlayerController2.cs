using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed = 5f;   // 이동 속도
    public float gravity = 9.8f;   // 중력
    private CharacterController controller;
    private Animator animator;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 입력 받기
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // 이동 벡터 설정
        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        // 이동 방향 설정
        if (move.magnitude > 0)
        {
            transform.forward = move; // 캐릭터가 이동 방향을 바라보도록 설정
        }

        // 중력 적용
        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // 이동 처리
        moveDirection = move * moveSpeed;
        controller.Move(moveDirection * Time.deltaTime);

        // 애니메이터 변수 업데이트
        animator.SetFloat("speed", move.magnitude);
    }
}
