using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; //ÃÑ¾Ë ÇÁ¸®ÆÕ
    public GameObject firePosition; //ÃÑ±¸


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
