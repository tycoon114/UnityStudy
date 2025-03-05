using UnityEngine;

public class P38Rotation : MonoBehaviour
{
    float rotationSpeed = 60.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        transform.Rotate(new Vector3(v,0,-h).normalized * rotationSpeed*Time.deltaTime);
    }
}
