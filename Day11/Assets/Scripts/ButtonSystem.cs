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
        Debug.Log("����");
        audioSourceBgm.Play(); // ����

    }

    public void pressStop() {

        Debug.Log("����");
        audioSourceBgm.Pause(); // ����
    }


}
