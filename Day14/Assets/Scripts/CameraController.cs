using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // ���� ĳ����
    public Vector3 offset = new Vector3(0, 2, -4); // ī�޶� ��ġ ����
    public float smoothSpeed = 5f; // �ε巯�� �̵� �ӵ�

    void LateUpdate()
    {
        if (target == null) return;

        // ��ǥ ��ġ ���
        Vector3 desiredPosition = target.position + offset;

        // �ε巴�� �̵�
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);

        // �׻� ĳ���͸� �ٶ󺸰� ����
        transform.LookAt(target);
    }
}
