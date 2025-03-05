using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 5.0f;

    private void Awake()
    {
        //여기서 this를 쓰면 클래스 자체를 지워버림
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        //transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
