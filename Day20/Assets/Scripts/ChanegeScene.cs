using UnityEngine;
using UnityEngine.SceneManagement;

public class ChanegeScene : MonoBehaviour
{
    public string sceneName;

    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }


}
