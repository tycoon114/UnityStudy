
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public float moveSpeeed = 4.0f;     //�̵� �ӵ�
    public float roateSpeed = 180.0f;   //ȸ�� �ӵ�
    public float mouseSensitivity = 100.0f;  //����
    public Transform cameraTransform;   //ī�޶� ��ġ��
    public CharacterController characterController;     //ĳ���� ��Ʈ�ѷ�
    public Transform playerHead;    // �÷��̾� �Ӹ� ��ġ (1��Ī ��带 ����)
    public float thirdPersonDistance = 3.0f;       // 3��Ī �������� ī�޶�� �÷��̾� ������ �Ÿ�
    public Vector3 thirdPersonOffset = new Vector3(0f, 1.5f, 0f);   //3��Ī ī�޶� ��ġ
    public Transform playerLookObj;     //�÷��̾� �þ� ��ġ

    public float zoomDistance = 1.0f;  //ī�޶� Ȯ��� �� �Ÿ� (3��Ī)
    public float zoomSpeed = 5.0f;   // Ȯ�� ��� �ӵ�
    public float defaultFov = 60.0f;    //�⺻ �þ߰�
    public float zoomFov = 30.0f;       //Ȯ�� �� ī�޶� �þ߰� (1��Ī)

    private float currentDistance;  //���� ī�޶���� �Ÿ� (3��Ī)
    private float taregetDistance; // ��ǥ ī�޶� �Ÿ�
    private float targetFov; //��ǥ Fov
    private bool isZoomed = false;  //Ȯ�� ���� Ȯ��
    private Coroutine zoomCoroutine;    //Ȯ�� ��� �ڷ�ƾ
    private Camera mainCamera;  //ī�޶� ������Ʈ

    private float pitch = 0.0f; //���Ʒ� ȸ�� �� 
    private float yaw = 0.0f;   //�¿� ȸ�� ��
    private bool isFirstPerson = false;     //1��Ī ��� ����
    private bool isRotaterAroundPlayer = true; //ī�޶� �÷��̾� ������ ȸ�� �ϰ� �ִ���

    //�߷� ���� ����
    public float gravity = -9.81f;
    public float jumpHeight = 2.0f;
    private Vector3 velocity;
    private bool isGround;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentDistance = thirdPersonDistance;
        taregetDistance = thirdPersonDistance;
        targetFov = defaultFov;
        mainCamera = cameraTransform.GetComponent<Camera>();
        mainCamera.fieldOfView = defaultFov;
    }

    void Update()
    {
        //���콺 �Է��� �޾� �÷��̾� ȸ��
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yaw += mouseX;
        pitch += mouseY;
        //�� �Ʒ� ���� ����
        pitch = Mathf.Clamp(pitch, -45f, 45f);

        isGround = characterController.isGrounded;
        //isGoounded ���� ó��
        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            isFirstPerson = !isFirstPerson;
            Debug.Log(isFirstPerson ? "1��Ī" : "3��Ī");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            isRotaterAroundPlayer = !isRotaterAroundPlayer;
            Debug.Log(isRotaterAroundPlayer ? "ī�޶� ������ ȸ��" : "�÷��̾ ���� ȸ��");
        }

        if (isFirstPerson)
        {
            FirstPersonMovement();
        }
        else
        {
            ThirdPersonMovement();
        }
    }

    void FirstPersonMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //�̵� ���� - ī�޶� �����ְ� �ִ� ȭ��
        Vector3 moveDirection = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        // ������ ����
        moveDirection.y = 0;

        //�ش� �������� �̵�
        characterController.Move(moveDirection * moveSpeeed * Time.deltaTime);

        //ī�޶��� ��ġ�� �÷��̾��� �Ӹ���
        cameraTransform.position = playerHead.position;
        //ī�޶� ȸ����
        cameraTransform.rotation = Quaternion.Euler(pitch, yaw, 0);

        transform.rotation = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0);
    }

    void ThirdPersonMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(move * moveSpeeed * Time.deltaTime);

        UpdateCameraPosition();
    }


    void UpdateCameraPosition()
    {

        if (isRotaterAroundPlayer)
        {
            //ī�޶� �÷��̾� �����ʿ��� ȸ���ϵ��� ����
            Vector3 direction = new Vector3(0, 0, -currentDistance);
            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

            //ī�޶� �÷��̾��� �����ʿ��� ������ ��ġ�� �̵�
            cameraTransform.position = transform.position + thirdPersonOffset + rotation * direction;

            //ī�޶� �÷��̾��� ��ġ�� ���󰡵��� ����
            cameraTransform.LookAt(transform.position + new Vector3(0, thirdPersonOffset.y, 0));
        }
        else
        {
            //�÷��̾ ���� ȸ��
            transform.rotation = Quaternion.Euler(0f, yaw, 0);
            Vector3 direction = new Vector3(0, 0, -currentDistance);
            cameraTransform.position = playerLookObj.position + thirdPersonOffset + Quaternion.Euler(pitch, yaw, 0) * direction;

            cameraTransform.LookAt(playerLookObj.position + new Vector3(0, thirdPersonOffset.y, 0));
        }
    }
}
