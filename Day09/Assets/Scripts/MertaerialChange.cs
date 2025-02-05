using UnityEngine;

public class MertaerialChange : MonoBehaviour
{

    public Material skyboxMaterial;
    public Material skyboxMaterial2;


    void Start()
    {
       // RenderSettings.skybox = skyboxMaterial;
    }

    public void skyChange(int score) {
        Debug.Log(score);

        if (score % 100 == 0)
        {
            RenderSettings.skybox = skyboxMaterial;
        }
        else {
            RenderSettings.skybox = skyboxMaterial2;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
