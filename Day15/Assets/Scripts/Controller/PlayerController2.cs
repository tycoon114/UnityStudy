using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed = 5f;   // �̵� �ӵ�
    public float gravity = 9.8f;   // �߷�
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
        // �Է� �ޱ�
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // �̵� ���� ����
        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        // �̵� ���� ����
        if (move.magnitude > 0)
        {
            transform.forward = move; // ĳ���Ͱ� �̵� ������ �ٶ󺸵��� ����
        }

        // �߷� ����
        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // �̵� ó��
        moveDirection = move * moveSpeed;
        controller.Move(moveDirection * Time.deltaTime);

        // �ִϸ����� ���� ������Ʈ
        animator.SetFloat("speed", move.magnitude);
    }
}
