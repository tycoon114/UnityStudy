using System.Collections;
using UnityEngine;



public class PlayerManager2 : MonoBehaviour
{
    private float moveSpeed = 5.0f; //�÷��̾� �̵� �ӵ�
    public float mouseSensitivity = 100.0f; // ���콺 ����
    public Transform cameraTransform; // ī�޶��� Transform
    public CharacterController characterController;
    public Transform playerHead; //�÷��̾� �Ӹ� ��ġ(1��Ī ��带 ���ؼ�)
    public float thirdPersonDistance = 3.0f; //3��Ī ��忡�� �÷��̾�� ī�޶��� �Ÿ�
    public Vector3 thirdPersonOffset = new Vector3(0f, 1.5f, 0f); //3��Ī ��忡�� ī�޶� ������
    public Transform playerLookObj; //�÷��̾� �þ� ��ġ

    public float zoomeDistance = 1.0f; //ī�޶� Ȯ��� ���� �Ÿ�(3��Ī ��忡�� ���)
    public float zoomSpeed = 5.0f; // Ȯ����Ұ� �Ǵ� �ӵ�
    public float defaultFov = 60.0f; //�⺻ ī�޶� �þ߰�
    public float zoomeFov = 30.0f; //Ȯ�� �� ī�޶� �þ߰�(1��Ī ��忡�� ���)

    private float currentDistance; //���� ī�޶���� �Ÿ�(3��Ī ���)
    private float targetDistance; //��ǥ ī�޶� �Ÿ�
    private float targetFov; //��ǥ FOV
    private bool isZoomed = false; //Ȯ�� ���� Ȯ��
    private Coroutine zoomCoroutine; //�ڷ�ƾ�� ����Ͽ� Ȯ�� ��� ó��
    private Camera mainCamera; //ī�޶� ������Ʈ

    private float pitch = 0.0f; //���Ʒ� ȸ�� ��
    private float yaw = 0.0f; //�¿� ȸ�� ��
    private bool isFirstPerson = false; //1��Ī ��� ����
    private bool isRotaterAroundPlayer = false; //ī�޶� �÷��̾� ������ ȸ���ϴ��� ���� 

    //�߷� ���� ����
    public float gravity = -9.81f;
    public float jumpHeight = 2.0f;
    private Vector3 velocity;
    private bool isGround;

    private Animator animator;
    private float horizontal;
    private float vertical;
    private bool isRunning = false;
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    private bool isAim = false;
    private bool isFire = false;
    private bool isOperate = false;

    public AudioClip audioClipFire;
    public AudioClip audioClipItemGet;
    private AudioSource audioSource;
    public AudioClip audioClipWeaponChange;
    public GameObject RifleM4Obj;
    private int animationSpeed = 1;
    private string currentAnimation = "Idle";

    public Transform aimTarget;

    private float weaponMaxDistance = 100.0f;
    public LayerMask TargetLayerMask;

    //public MultiAimConstraint multiAimConstraint;


    public Vector3 boxSize = new Vector3(1.0f, 1.0f, 1.0f);
    public float castDistance = 5.0f;
    public LayerMask itemLayer;
    public Transform itemGetPos;

    public GameObject crosshairObj;
    public GameObject m4IconImage;


    bool isGetM4Item = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentDistance = thirdPersonDistance;
        targetDistance = thirdPersonDistance;
        targetFov = defaultFov;
        mainCamera = cameraTransform.GetComponent<Camera>();
        mainCamera.fieldOfView = defaultFov;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        RifleM4Obj.SetActive(false);
        crosshairObj.SetActive(false);
        m4IconImage.SetActive(false);
    }

    void Update()
    {
        MouseSet();
        CameraSet();
        PlayerMovement();
        AimSet();
        WeaponFire();
        Run();
        WeaponChange();
        AnimationSet();
        Operate();

        animator.speed = animationSpeed;

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName(currentAnimation) && stateInfo.normalizedTime >= 1.0f)
        {
            currentAnimation = "Attack";
            animator.Play(currentAnimation);
        }
    }


    void UpdateAimTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        aimTarget.position = ray.GetPoint(10.0f);
    }

    void Operate()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKeyDown(KeyCode.E) && !stateInfo.IsName("PickUp"))
        {
            animator.SetTrigger("Operate");
        }
    }

    public void ItemBoxCast()
    {
        Vector3 origin = itemGetPos.position;
        Vector3 direction = itemGetPos.forward;
        RaycastHit[] hits;
        hits = Physics.BoxCastAll(origin, boxSize / 2, direction, Quaternion.identity, castDistance, itemLayer);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.name == "ItemM4")
            {
                hit.collider.gameObject.SetActive(false);
                audioSource.PlayOneShot(audioClipItemGet);
                m4IconImage.SetActive(true);
                isGetM4Item = true;
            }

        }
    }

    void MouseSet()
    {
        //���콺 �Է��� �޾� ī�޶�� �÷��̾� ȸ�� ó��
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -45f, 45f);

        isGround = characterController.isGrounded;

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    void CameraSet()
    {

        if (Input.GetKeyDown(KeyCode.V))
        {
            isFirstPerson = !isFirstPerson;
            Debug.Log(isFirstPerson ? "1��Ī ���" : "3��Ī ���");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            isRotaterAroundPlayer = !isRotaterAroundPlayer;
            Debug.Log(isRotaterAroundPlayer ? "ī�޶� ������ ȸ���մϴ�." : "�÷��̾ �þ߿� ���� ȸ���մϴ�.");
        }
    }

    void PlayerMovement()
    {
        if (isFirstPerson)
        {
            FirstPersonMovement();
        }
        else
        {
            ThirdPersonMovement();
        }
    }

    void WeaponChange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isGetM4Item)
        {
            animator.SetTrigger("isWeaponChange");
            RifleM4Obj.SetActive(true);
        }
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        moveSpeed = isRunning ? runSpeed : walkSpeed;
    }

    void WeaponFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isAim)
            {
                //Weapon Type MaxDistance Set
                weaponMaxDistance = 1000.0f;

                isFire = true;
                animator.SetTrigger("isShoot");

                Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
                RaycastHit[] hits = Physics.RaycastAll(ray, weaponMaxDistance, TargetLayerMask);

                if (hits.Length > 0)
                {
                    for (int i = 0; i < hits.Length && i < 2; i++)
                    {
                        Debug.Log("�浹 : " + hits[i].collider.name);
                        Debug.DrawLine(ray.origin, hits[i].point, Color.red, 3.0f);
                    }

                }
                else
                {
                    Debug.DrawLine(ray.origin, ray.origin + ray.direction * weaponMaxDistance, Color.green, 3.0f);
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isFire = false;
        }
    }

    void AimSet()
    {
        if (Input.GetMouseButtonDown(1) && isGetM4Item)
        {
            isAim = true;
            //multiAimConstraint.data.offset = new Vector3(-30, 0, 0);
            crosshairObj.SetActive(true);
            //animator.SetBool("IsAim", isAim);
            animator.SetLayerWeight(1, 1);
            if (zoomCoroutine != null)
            {
                StopCoroutine(zoomCoroutine);
            }

            if (isFirstPerson)
            {
                SetTargetFOV(zoomeFov);
                zoomCoroutine = StartCoroutine(ZoomFieldOfView(targetFov));
            }
            else
            {
                SetTargetDistance(zoomeDistance);
                zoomCoroutine = StartCoroutine(ZoomCamera(targetDistance));
            }
        }

        if (Input.GetMouseButtonUp(1) && isGetM4Item)
        {
            isAim = false;
            crosshairObj.SetActive(false);
            //multiAimConstraint.data.offset = new Vector3(0, 0, 0);
            //animator.SetBool("IsAim", isAim);
            animator.SetLayerWeight(1, 0);
            if (zoomCoroutine != null)
            {
                StopCoroutine(zoomCoroutine);
            }

            if (isFirstPerson)
            {
                SetTargetFOV(defaultFov);
                zoomCoroutine = StartCoroutine(ZoomFieldOfView(targetFov));
            }
            else
            {
                SetTargetDistance(thirdPersonDistance);
                zoomCoroutine = StartCoroutine(ZoomCamera(targetDistance));
            }
        }
    }

    void AnimationSet()
    {
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetBool("IsRunning", isRunning);
    }

    void FirstPersonMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        moveDirection.y = 0;
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        cameraTransform.position = playerHead.position;
        cameraTransform.rotation = Quaternion.Euler(pitch, yaw, 0);
        transform.rotation = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0);
    }

    void ThirdPersonMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(move * moveSpeed * Time.deltaTime);

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
            //�÷��̾ ���� ȸ���ϴ� ���
            transform.rotation = Quaternion.Euler(0f, yaw, 0);
            Vector3 direction = new Vector3(0, 0, -currentDistance);
            cameraTransform.position = playerLookObj.position + thirdPersonOffset + Quaternion.Euler(pitch, yaw, 0) * direction;
            cameraTransform.LookAt(playerLookObj.position + new Vector3(0, thirdPersonOffset.y, 0));

            UpdateAimTarget();
        }
    }


    public void SetTargetDistance(float distance)
    {
        targetDistance = distance;
    }

    public void SetTargetFOV(float fov)
    {
        targetFov = fov;
    }

    IEnumerator ZoomCamera(float targetDistance)
    {
        while (Mathf.Abs(currentDistance - targetDistance) > 0.01f) //���� �Ÿ����� ��ǥ �Ÿ��� �ε巴�� �̵�
        {
            currentDistance = Mathf.Lerp(currentDistance, targetDistance, Time.deltaTime * zoomSpeed);
            yield return null;
        }

        currentDistance = targetDistance; // ��ǥ �Ÿ��� ������ �� ���� ����
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

    public void WeaponChangeSoundOn()
    {
        audioSource.PlayOneShot(audioClipWeaponChange);
    }

    public void WeaponFireSoundOn()
    {
        audioSource.PlayOneShot(audioClipFire);
    }

    public void MovementSoundOn()
    {
        animationSpeed = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerDamage"))
        {
            animator.SetTrigger("Damage");
            audioSource.PlayOneShot(audioClipFire);
            GetComponent<CharacterController>().enabled = false;
            transform.position = Vector3.zero;
            GetComponent<CharacterController>().enabled = true;

        }

    }
}
