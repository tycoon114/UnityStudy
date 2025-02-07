using UnityEngine;
using UnityEngine.Audio;



//AudioUI오브젝트에 연결
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
        //여러개를 받아 오므로 GetComponents
        board = GetComponentsInChildren<Board>();

        //오브젝트를 생성해서 컴포넌트에 등록
        if (audioSource == null)
        {
            //오디오 소스 게임 오브젝트를 생성하고, 해당 오브젝트에 오디오소스 컴포넌트를 추가
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
        // samlples = FFT(신호에 대한 주파수 영역) 를 저장할 배열, 이 배열 값은 2의 제곱 수로 표현
        // 채널은 최대 8개의 채널을 지원해 주고 있음, 일반적으로는 0 사용
        //FFTWindow는 샘플링 진할할 때 쓰는 값
        float[] data = audioSource.GetSpectrumData(samples, 0, FFTWindow.Rectangular);

        for (int i = 0; i < board.Length; i++) {
            var size = board[i].GetComponent<RectTransform>().rect.size;

            size.y = minBoard + (data[i] *(maxBoard-minBoard) * 3.0f);

            board[i].GetComponent<RectTransform>().sizeDelta = size;

        }

    }
}
