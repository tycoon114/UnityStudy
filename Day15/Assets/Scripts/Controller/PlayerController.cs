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


    public float speed = 5f;       // 이동 속도
    public float gravity = -9.81f; // 중력 값

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        _state = PlayerState.Idle;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A, D 또는 좌우 화살표
        float moveZ = Input.GetAxis("Vertical");   // W, S 또는 상하 화살표

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime); // 이동 처리

        // 중력 적용
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
