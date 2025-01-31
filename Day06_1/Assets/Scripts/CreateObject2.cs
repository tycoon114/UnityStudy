using UnityEngine;

public class Create : MonoBehaviour
{

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
