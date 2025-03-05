using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }
}
