using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public enum PlayerState
    {
        Idle,
        Move,
        Attack,
        Dead
    }

    public PlayerState _state;


    public float speed = 5f;       // �̵� �ӵ�
    public float gravity = -9.81f; // �߷� ��
    public float jumpSpeed = 3.0f;

    private CharacterController controller;
    private Vector3 velocity;
    private Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        _state = PlayerState.Idle;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A, D �Ǵ� �¿� ȭ��ǥ
        float moveZ = Input.GetAxis("Vertical");   // W, S �Ǵ� ���� ȭ��ǥ

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime); // �̵� ó��

        if (move != Vector3.zero)
        {
            // ���� �������� ĳ���� ȸ��
            anim.SetBool("IsMove", true);
        }
        else
        {
            anim.SetBool("IsMoveEnd", true);
            anim.SetBool("IsMove", false);
        }



        // �߷� ����
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //���� �ϴ� �߿� ������ �Ұ���, ������ �̵��� ����
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                velocity.y = 7.5f;
        }


    }
}
