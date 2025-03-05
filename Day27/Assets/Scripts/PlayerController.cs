using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float rotateSpeed = 60.0f;
    private float speed = 5.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 angle = transform.rotation.eulerAngles;
        angle.z = rotateSpeed * -h * Time.deltaTime;

        transform.Translate(Vector3.up * v * Time.deltaTime * speed);

        transform.eulerAngles += transform.forward * -h * Time.deltaTime * rotateSpeed;

    }
}
