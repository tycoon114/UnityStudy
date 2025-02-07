using UnityEngine;
using UnityEngine.Audio;



//AudioUI������Ʈ�� ����
public class AudioBoardVisualizer : MonoBehaviour
{

    public float minBoard = 50.0f;

    public float maxBoard = 300.0f;

    public Board[] board;

    public AudioClip audioClip;

    public AudioSource audioSource;

    public AudioMixer audioMixer;

    public int samples = 64;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�������� �޾� ���Ƿ� GetComponents
        board = GetComponentsInChildren<Board>();

        //������Ʈ�� �����ؼ� ������Ʈ�� ���
        if (audioSource == null)
        {
            //����� �ҽ� ���� ������Ʈ�� �����ϰ�, �ش� ������Ʈ�� ������ҽ� ������Ʈ�� �߰�
            audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
        }
        else { 
            audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        }

        audioSource.clip = audioClip;
        audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[0];
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        // samlples = FFT(��ȣ�� ���� ���ļ� ����) �� ������ �迭, �� �迭 ���� 2�� ���� ���� ǥ��
        // ä���� �ִ� 8���� ä���� ������ �ְ� ����, �Ϲ������δ� 0 ���
        //FFTWindow�� ���ø� ������ �� ���� ��
        float[] data = audioSource.GetSpectrumData(samples, 0, FFTWindow.Rectangular);

        for (int i = 0; i < board.Length; i++) {
            var size = board[i].GetComponent<RectTransform>().rect.size;

            size.y = minBoard + (data[i] *(maxBoard-minBoard) * 3.0f);

            board[i].GetComponent<RectTransform>().sizeDelta = size;

        }

    }
}
