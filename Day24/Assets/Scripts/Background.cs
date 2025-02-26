using UnityEngine;

//��� ��ũ�� ���

// ���͸����� ������ ���� ������ ����

//�ʿ��� �� ��ũ�� �ӵ�, ���͸���
// ���� ��ũ�� 

public class Background : MonoBehaviour
{
    public Material backgroundMaterial;
    public float scrollSpeed = 0.1f;

    private void Update()
    {
        Vector2 dir = Vector2.up;

        backgroundMaterial.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;
    }

}
