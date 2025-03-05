using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;
    public float positionLagTime = 3.0f;
    public float rotationLagTime = 3.0f;

    Vector3 currentVelocity;

    public float smoothTime = 0.3f;
    public bool isRotationLag = false;
    public bool isPositionLag = false;

    public Quaternion saveLocation;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isPositionLag)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref currentVelocity, smoothTime);
        }
        else { 
            transform.position = player.position;
        }

        if (isRotationLag) {
            transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, Time.deltaTime * rotationLagTime);
        }


        if (Input.GetButtonDown("Camera")) {
            saveLocation = transform.rotation;
        }

        if (Input.GetButtonUp("Camera"))
        {
            transform.rotation = saveLocation;
        }


        if (Input.GetButton("Camera"))
        {
            transform.Rotate(new Vector3(0, Input.mousePositionDelta.x, 0) * 180.0f * Time.deltaTime);
        }


        float wheelDelta = (Input.GetAxisRaw("Mouse ScrollWheel"));

        Vector3 moveDirection = player.position - Camera.main.transform.position;  // πÊ«‚ ∫§≈Õ
        Camera.main.transform.Translate(moveDirection.normalized * Time.deltaTime * wheelDelta * 200.0f);

        

        //transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime* positionLagTime);
    
    }
}
