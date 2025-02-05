using UnityEngine;

public class MertaerialChange : MonoBehaviour
{

    public Material skyboxMaterial;

    void Start()
    {
        RenderSettings.skybox = skyboxMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
