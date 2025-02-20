using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float leftLimit = 0.0f;
    public float rightLimit = 0.0f;
    public float topLimit = 0.0f;
    public float bottomLimit = 0.0f;


    public GameObject subScreen;

    //��ũ�� ���� 
    public bool isForceScrollX = false;
    public bool isForceScrollY = false;
    public float forceScrollSpeedX = 0.5f;
    public float forceScrollSpeedY = 0.5f;



    void Update()
    {
        //�÷��̾ �˻�
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = transform.position.z;

        //���� ���� ��ũ��
        if (isForceScrollX) { 
            x = transform.position.x + (forceScrollSpeedX * Time.deltaTime);
        }



        //���� ���⿡ ���� ����ȭ
        if (x < leftLimit)
        {
            x = leftLimit;
        }

        else if (x > rightLimit)
        {
            x = rightLimit;
        }

        //���� ���� ��ũ��
        if (isForceScrollY)
        {
            y = transform.position.y + (forceScrollSpeedY * Time.deltaTime);
        }

        //���� ���⿡ ���� ����ȭ
        if (y < bottomLimit)
        {
            y = bottomLimit;
        }
        else if (y > topLimit)
        {
            y = topLimit;
        }
        //������ ī�޶� ��ġ�� ����3�� ǥ��
        Vector3 vector3 = new Vector3(x, y, z);
        //ī�޶��� ��ġ�� ������ ������ ����
        transform.position = vector3;

        if (subScreen != null) { 
            y = subScreen.transform.position.y;
            z= subScreen.transform.position.z;

            Vector3 v = new Vector3(x * 0.5f, y, z);

            subScreen.transform.position = v;
        }

    }
}
