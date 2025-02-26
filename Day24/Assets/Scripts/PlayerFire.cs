using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; //�Ѿ� ������
    public GameObject firePosition; //�ѱ�


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position;
        }
    }
}
