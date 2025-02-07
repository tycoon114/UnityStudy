using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ButtonSystem : MonoBehaviour
{
    public AudioSource audioSourceBgm;

    public Button startSound;
    public Button stopSound;

    private void Start()
    {
        

    }

    public void pressStart() {
        Debug.Log("시작");
        audioSourceBgm.Play(); // 실행

    }

    public void pressStop() {

        Debug.Log("정지");
        audioSourceBgm.Pause(); // 정지
    }


}
