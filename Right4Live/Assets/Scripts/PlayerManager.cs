
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerManager : MonoBehaviour
{
    private float moveSpeeed = 3.0f;     //�̵� �ӵ�
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
    private float targetDistance; // ��ǥ ī�޶� �Ÿ�
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


    private Animator animator;
    private float horizontal;
    private float vertical;
    private bool isRunning = false;
    public float walkSpeed = 3.0f;
    public float runSpeed = 7.0f;
    private bool isAim = false;
    private bool isShoot = false;
    

    public AudioClip audioClipFire;
    private AudioSource audioSource;
    public GameObject RifleM4Obj;
    public AudioClip audioWeaponChange;


    void Start()
    {
        RifleM4Obj.SetActive(false);
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        currentDistance = thirdPersonDistance;
        targetDistance = thirdPersonDistance;
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

        if (Input.GetMouseButtonDown(1))
        {
            isAim = true;
            animator.SetBool("isAim", isAim);
            //ī�޶� ������ �����̱� ���� �ڷ�ƾ ���
            //�ڷ�ƾ�� ����ǰ� �ִ��� Ȯ�� �ϱ� ����
            if (zoomCoroutine != null)
            {
                StopCoroutine(zoomCoroutine);
            }

            if (isFirstPerson)
            {
                //1��Ī �����̸� ī�޶� ��ġ�� �ƴ� FOV�� ����
                SetTargetFov(zoomFov);
                zoomCoroutine = StartCoroutine(ZoomFieldOfView(targetFov));
            }
            else
            {
                //3��Ī�̸� ī�޶� �Ÿ��� ����
                SetTargetDistance(zoomDistance);
                zoomCoroutine = StartCoroutine(ZoomCamera(targetDistance));
            }

        }

        if (Input.GetMouseButtonUp(1))
        {
            isAim = false;
            animator.SetBool("isAim", isAim);
            if (zoomCoroutine != null)
            {
                StopCoroutine(zoomCoroutine);
            }

            if (isFirstPerson)
            {
                SetTargetFov(defaultFov);
                zoomCoroutine = StartCoroutine(ZoomFieldOfView(targetFov));
            }
            else
            {
                SetTargetDistance(thirdPersonDistance);
                zoomCoroutine = StartCoroutine(ZoomCamera(targetDistance));
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (isAim)
            {
                isShoot = true;
                animator.SetBool("isShoot", isShoot);
                audioSource.PlayOneShot(audioClipFire);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isShoot = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;

        }
        else
        {
            isRunning = false;
        }


        if (Input.GetKeyDown(KeyCode.Alpha1)) { 
            audioSource.PlayOneShot(audioWeaponChange);
            animator.SetTrigger("isWeaponChange");
            RifleM4Obj.SetActive(true);

        }


        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetBool("isRunning", isRunning);

        moveSpeeed = isRunning ? runSpeed : walkSpeed;
    }

    void FirstPersonMovement()
    {
        if (!isAim)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            //�̵� ���� - ī�޶� �����ְ� �ִ� ȭ��
            Vector3 moveDirection = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
            // ������ ����
            moveDirection.y = 0;

            //�ش� �������� �̵�
            characterController.Move(moveDirection * moveSpeeed * Time.deltaTime);
        }



        //ī�޶��� ��ġ�� �÷��̾��� �Ӹ���
        cameraTransform.position = playerHead.position;
        //ī�޶� ȸ����
        cameraTransform.rotation = Quaternion.Euler(pitch, yaw, 0);

        transform.rotation = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0);
    }

    void ThirdPersonMovement()
    {
        if (!isAim)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            Vector3 move = transform.right * horizontal + transform.forward * vertical;
            characterController.Move(move * moveSpeeed * Time.deltaTime);
        }



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
            cameraTransform.LookAt(transform.position + new Vector3(0.5f, thirdPersonOffset.y, 0));
        }
        else
        {
            //�÷��̾ ���� ȸ��
            transform.rotation = Quaternion.Euler(0f, yaw, 0);
            Vector3 direction = new Vector3(0, 0, -currentDistance);
            cameraTransform.position = playerLookObj.position + thirdPersonOffset + Quaternion.Euler(pitch, yaw, 0) * direction;

            cameraTransform.LookAt(playerLookObj.position + new Vector3(0.5f, thirdPersonOffset.y, 0));
        }
    }

    public void SetTargetDistance(float distance)
    {
        targetDistance = distance;
    }

    public void SetTargetFov(float fov)
    {
        targetFov = fov;
    }





    IEnumerator ZoomCamera(float targetDistance)
    {
        while (Mathf.Abs(currentDistance - targetDistance) > 0.01f)     //���� �Ÿ����� ��ǥ �Ÿ��� �ε巴�� �̵�
        {
            currentDistance = Mathf.Lerp(currentDistance, targetDistance, Time.deltaTime * zoomSpeed);
            yield return null;
        }
        currentDistance = targetDistance;   //��ǥ �Ÿ� ������ �� ���� ����
    }

    IEnumerator ZoomFieldOfView(float targetFov)
    {
        while (Mathf.Abs(mainCamera.fieldOfView - targetFov) > 0.01f)
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, targetFov, Time.deltaTime * zoomSpeed);
            yield return null;
        }
        mainCamera.fieldOfView = targetFov;
    }



}
