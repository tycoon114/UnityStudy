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

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        _state = PlayerState.Idle;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A, D �Ǵ� �¿� ȭ��ǥ
        float moveZ = Input.GetAxis("Vertical");   // W, S �Ǵ� ���� ȭ��ǥ

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime); // �̵� ó��

        // �߷� ����
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
