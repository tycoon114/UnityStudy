using UnityEngine;
using UnityEngine.UI;

public class AudioSourceSample : MonoBehaviour
{
    //0) 인스펙터에서 직접 연결
    public AudioSource audioSourceBgm;

    //1) AudioSorceSample 객체가 자체적으로 오디오 소스를 가지고 있는 경우, GetComponent<T>를 통해 오디오 소스 연결 가능
    //private AudioSource ownAudioSource;

    //3) 씬에서 찾아서 연결 하는 경우, GameObject.Find().GetComponent<T>를 통해 연결
    public AudioSource audioSourceSFX;

    public AudioClip bgm; // 오디오 클립에 대한 연결

    //4) Resource.Load 기능을 이용해서 리소스 폴데 내의 오디오 소스 클립을 받아오기
    


    void Start()
    {
        //1) ->
        //ownAudioSource = GetComponent<AudioSource>();
    
        //3) -> Find는 씬에서 찾은 게임 오브젝트를 리턴 하는 기능을 가지고 있음
        audioSourceSFX = GameObject.Find("SFX").GetComponent<AudioSource>();

        audioSourceBgm.clip = bgm;

        //리소스 폴더에서 오브젝트를 찾아 로드, 이때 받아오는 값은 오브젝트이므로, as 클래스명을 통해 해당 데이터가 어떤 데이터인지 표현해주면 그 형태로 받아오게 된다.
        audioSourceSFX.clip = Resources.Load("Explosion") as AudioClip;

        //리소스 로드 시 경로가 정해져 있다면 폴더명/파일명 으로 작성
        //리소스 로드 시 작성하는 이름에는 확장자명을 작성하지 않음
        audioSourceSFX.clip = Resources.Load("Audio/BombCharge") as AudioClip;


        audioSourceBgm.Play(); // 실행
        //audioSourceBgm.Pause(); // 일시정지
        //audioSourceBgm.UnPause(); // 일시 정지 해제
        //audioSourceSFX.PlayOneShot(bgm); //클립 하나를 한순간 플레이
        //audioSourceBgm.Stop(); // 실행중지
        //audioSourceBgm.PlayDelayed(1.0f); // 1초 뒤에 재생, 재생에 딜레이를 설정
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
