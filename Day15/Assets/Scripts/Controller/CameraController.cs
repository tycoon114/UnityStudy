using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // 따라갈 캐릭터
    public Vector3 offset = new Vector3(0, 2.0f, -4.0f); // 카메라 위치 조정
    public float smoothSpeed = 5f; // 부드러운 이동 속도

    void LateUpdate()
    {
        if (target == null) return;

        // 목표 위치 계산
        Vector3 desiredPosition = target.position + offset;

        // 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);

        // 항상 캐릭터를 바라보게 설정
        transform.LookAt(target);
    }
}
