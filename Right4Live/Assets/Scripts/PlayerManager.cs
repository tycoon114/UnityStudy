
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerManager : MonoBehaviour
{
    private float moveSpeeed = 3.0f;     //이동 속도
    public float roateSpeed = 180.0f;   //회전 속도
    public float mouseSensitivity = 100.0f;  //감도
    public Transform cameraTransform;   //카메라 위치값
    public CharacterController characterController;     //캐릭터 컨트롤러
    public Transform playerHead;    // 플레이어 머리 위치 (1인칭 모드를 위함)
    public float thirdPersonDistance = 3.0f;       // 3인칭 시점에서 카메라와 플레이어 사이의 거리
    public Vector3 thirdPersonOffset = new Vector3(0f, 1.5f, 0f);   //3인칭 카메라 위치
    public Transform playerLookObj;     //플레이어 시야 위치

    public float zoomDistance = 1.0f;  //카메라가 확대될 때 거리 (3인칭)
    public float zoomSpeed = 5.0f;   // 확대 축소 속도
    public float defaultFov = 60.0f;    //기본 시야값
    public float zoomFov = 30.0f;       //확대 시 카메라 시야각 (1인칭)

    private float currentDistance;  //현재 카메라와의 거리 (3인칭)
    private float targetDistance; // 목표 카메라 거리
    private float targetFov; //목표 Fov
    private bool isZoomed = false;  //확대 여부 확인
    private Coroutine zoomCoroutine;    //확대 축소 코루틴
    private Camera mainCamera;  //카메라 컴포넌트

    private float pitch = 0.0f; //위아래 회전 값 
    private float yaw = 0.0f;   //좌우 회전 값
    private bool isFirstPerson = false;     //1인칭 모드 여부
    private bool isRotaterAroundPlayer = true; //카메라가 플레이어 주위를 회전 하고 있는지

    //중력 관련 변수
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
        //마우스 입력을 받아 플레이어 회전
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yaw += mouseX;
        pitch += mouseY;
        //위 아래 각도 제한
        pitch = Mathf.Clamp(pitch, -45f, 45f);

        isGround = characterController.isGrounded;
        //isGoounded 예외 처리
        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            isFirstPerson = !isFirstPerson;
            Debug.Log(isFirstPerson ? "1인칭" : "3인칭");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            isRotaterAroundPlayer = !isRotaterAroundPlayer;
            Debug.Log(isRotaterAroundPlayer ? "카메라가 주위를 회전" : "플레이어가 직접 회전");
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
            //카메라를 서서히 움직이기 위해 코루틴 사용
            //코루틴이 실행되고 있는지 확인 하기 위함
            if (zoomCoroutine != null)
            {
                StopCoroutine(zoomCoroutine);
            }

            if (isFirstPerson)
            {
                //1인칭 시점이면 카메라 위치가 아닌 FOV값 수정
                SetTargetFov(zoomFov);
                zoomCoroutine = StartCoroutine(ZoomFieldOfView(targetFov));
            }
            else
            {
                //3인칭이면 카메라 거리를 수정
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

            //이동 방향 - 카메라가 보여주고 있는 화면
            Vector3 moveDirection = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
            // 없으면 버그
            moveDirection.y = 0;

            //해당 방향으로 이동
            characterController.Move(moveDirection * moveSpeeed * Time.deltaTime);
        }



        //카메라의 위치를 플레이어의 머리로
        cameraTransform.position = playerHead.position;
        //카메라 회전값
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
            //카메라가 플레이어 오른쪽에서 회전하도록 설정
            Vector3 direction = new Vector3(0, 0, -currentDistance);
            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

            //카메라를 플레이어의 오른쪽에서 고정된 위치로 이동
            cameraTransform.position = transform.position + thirdPersonOffset + rotation * direction;

            //카메라가 플레이어의 위치를 따라가도록 설정
            cameraTransform.LookAt(transform.position + new Vector3(0.5f, thirdPersonOffset.y, 0));
        }
        else
        {
            //플레이어가 직접 회전
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
        while (Mathf.Abs(currentDistance - targetDistance) > 0.01f)     //현재 거리에서 목표 거리로 부드럽게 이동
        {
            currentDistance = Mathf.Lerp(currentDistance, targetDistance, Time.deltaTime * zoomSpeed);
            yield return null;
        }
        currentDistance = targetDistance;   //목표 거리 도달한 후 값을 고정
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
