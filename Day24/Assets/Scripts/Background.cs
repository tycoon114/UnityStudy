using UnityEngine;

//배경 스크롤 기능

// 머터리얼의 오프셋 값을 조정할 예정

//필요한 것 스크롤 속도, 머터리얼
// 위로 스크롤 

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
