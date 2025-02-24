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
  
    }

    private void FixedUpdate()
    {
        // �Է� �ޱ�
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // �̵� ���� ����
        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        // speed �� �ﰢ �ݿ� (Ű�� ������ ��� �ִϸ��̼� ��ȯ��)
        float speed = move.magnitude;

        bool isMoving = move.magnitude > 0;
        animator.SetBool("isMoving", isMoving);

        // �̵� ���̸� ������ ����
        //���⼭ �ڷ� ���� ��� ������ �������� �ʵ��� ����ߵ�
        if (isMoving)
        {
            transform.forward = move;
        }

        // �߷� ����
        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else
        {
            moveDirection.y = 0; // �ٴڿ� ������ �߷� �ʱ�ȭ
        }

        // �̵� ó��
        moveDirection = move * moveSpeed;
        controller.Move(moveDirection * Time.deltaTime);
    }

}
