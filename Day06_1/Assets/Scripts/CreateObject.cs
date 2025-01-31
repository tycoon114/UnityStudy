using UnityEngine;

public class CreateObject : MonoBehaviour
{

    public GameObject prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Instantiate(prefab);

        Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
