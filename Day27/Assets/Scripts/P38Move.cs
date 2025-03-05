using UnityEngine;

public class P38Move : MonoBehaviour
{

    public float moveSpeeed = 30.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeeed*Time.deltaTime);
    }
}
