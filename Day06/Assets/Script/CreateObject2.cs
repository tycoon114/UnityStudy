using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created



    public GameObject prefab;

    private GameObject square;



    void Start()
    {
        square = Instantiate(prefab);

        Destroy(square);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
