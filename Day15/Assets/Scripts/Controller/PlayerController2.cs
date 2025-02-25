using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed = 5f;   // �̵� �ӵ�
    public float gravity = 9.8f;   // �߷�
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
        // �Է� �ޱ�
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // �̵� ���� ����
        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        // ���� ī�޶��� ȸ�� �� ��������
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        // Y�� ���� ���� (���� �̵� ����)
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        // ����ȭ (���̸� 1�� ����)
        cameraForward.Normalize();
        cameraRight.Normalize();


        // speed �� �ﰢ �ݿ� (Ű�� ������ ��� �ִϸ��̼� ��ȯ��)
        float speed = move.magnitude;

        bool isMoving = move.magnitude > 0;
        animator.SetBool("isMoving", isMoving);

        //@TK(25.02.24)
        //animator.SetFloat("FactorX", moveX);
        //animator.SetFloat("FactorZ", moveZ);


        // �̵� ���̸� ������ ����
        //���⼭ �ڷ� ���� ��� ������ �������� �ʵ��� ����ߵ� ,&& Input.GetKeyDown(KeyCode.W) 
        //if (isMoving )
        //{
        //    transform.forward = move;
        //}

        //���� �������� ȸ��2

        //if (!(moveX == 0 && moveZ == 0)) {
        //    //�̵��� ȸ���� ���� ó��
        //    transform.position += move * speed * Time.deltaTime;
        //    //ȸ���ϴ� �κ�
        //    transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(move),Time.deltaTime);
        //}

        if (Input.GetMouseButton(1))
        {
            isAim = true;
            animator.SetBool("isAim", isAim);
        }
        else
        {
            isAim = false;
            animator.SetBool("isAim", isAim);
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

        // ����� �̵� ó�� (��)
        //moveDirection = move * moveSpeed;
        //controller.Move(moveDirection * Time.deltaTime);


        // �Է� ���� ī�޶� �������� ��ȯ
        moveDirection = (cameraForward * moveZ + cameraRight * moveX).normalized;
        // �̵� ó��
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (isAim)
        {
            transform.rotation = Quaternion.LookRotation(cameraForward); // ������ ���� ����
        }
        else if (moveDirection != Vector3.zero)// �̵� ���̸� �̵� �������� ĳ���� ȸ��
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * 10f);
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        //// ī�޶� �̵� ������ ���� ���ݾ� ȸ��
        //Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        //Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, targetRotation, Time.deltaTime * 2f);


    }

}
