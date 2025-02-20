using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float leftLimit = 0.0f;
    public float rightLimit = 0.0f;
    public float topLimit = 0.0f;
    public float bottomLimit = 0.0f;


    public GameObject subScreen;

    //스크롤 강제 
    public bool isForceScrollX = false;
    public bool isForceScrollY = false;
    public float forceScrollSpeedX = 0.5f;
    public float forceScrollSpeedY = 0.5f;



    void Update()
    {
        //플레이어를 검색
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = transform.position.z;

        //가로 강제 스크롤
        if (isForceScrollX) { 
            x = transform.position.x + (forceScrollSpeedX * Time.deltaTime);
        }



        //가로 방향에 대한 동기화
        if (x < leftLimit)
        {
            x = leftLimit;
        }

        else if (x > rightLimit)
        {
            x = rightLimit;
        }

        //세로 강제 스크롤
        if (isForceScrollY)
        {
            y = transform.position.y + (forceScrollSpeedY * Time.deltaTime);
        }

        //세로 방향에 대한 동기화
        if (y < bottomLimit)
        {
            y = bottomLimit;
        }
        else if (y > topLimit)
        {
            y = topLimit;
        }
        //현재의 카메라 위치를 벡터3로 표현
        Vector3 vector3 = new Vector3(x, y, z);
        //카메라의 위치를 설정한 값으로 적용
        transform.position = vector3;

        if (subScreen != null) { 
            y = subScreen.transform.position.y;
            z= subScreen.transform.position.z;

            Vector3 v = new Vector3(x * 0.5f, y, z);

            subScreen.transform.position = v;
        }

    }
}
