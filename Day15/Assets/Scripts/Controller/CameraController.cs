using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 2.0f, -4.0f); // ī�޶� ��ġ ����
    public float smoothSpeed = 5f; // �ε巯�� �̵� �ӵ�
    public Transform player; // �÷��̾� ĳ����
    public float sensitivity = 2.0f; // ���콺 ����
    public float zoomFOV = 20f; // �� �� FOV
    public float normalFOV = 40f; // �⺻ FOV

    private float pitch = 0f; // ���Ʒ� ȸ��
    private float yaw = 0f; // �¿� ȸ��
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked; // ���콺 ���
        Cursor.visible = false;
    }

    void Update()
    {
        //// ��ǥ ��ġ ���
        Vector3 desiredPosition = player.position + offset;

        //// �ε巴�� �̵�
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);

        //// �׻� ĳ���͸� �ٶ󺸰� ����
        //transform.LookAt(target);

        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -30f, 60f); // ���Ʒ� ���� ����

        // ī�޶� ��ġ �� ȸ�� ����
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        transform.position = player.position + rotation * offset;
        transform.LookAt(player.position);

        // ��Ŭ�� �� �� (FOV ����)
        float targetFOV = Input.GetMouseButton(1) ? zoomFOV : normalFOV;
        cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, targetFOV, Time.deltaTime * 100f); // �� ������ �� ����

    }
}
