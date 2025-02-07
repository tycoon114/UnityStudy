using UnityEngine;
using UnityEngine.UI;

public class AudioSourceSample : MonoBehaviour
{
    //0) �ν����Ϳ��� ���� ����
    public AudioSource audioSourceBgm;

    //1) AudioSorceSample ��ü�� ��ü������ ����� �ҽ��� ������ �ִ� ���, GetComponent<T>�� ���� ����� �ҽ� ���� ����
    //private AudioSource ownAudioSource;

    //3) ������ ã�Ƽ� ���� �ϴ� ���, GameObject.Find().GetComponent<T>�� ���� ����
    public AudioSource audioSourceSFX;

    public AudioClip bgm; // ����� Ŭ���� ���� ����

    //4) Resource.Load ����� �̿��ؼ� ���ҽ� ���� ���� ����� �ҽ� Ŭ���� �޾ƿ���
    


    void Start()
    {
        //1) ->
        //ownAudioSource = GetComponent<AudioSource>();
    
        //3) -> Find�� ������ ã�� ���� ������Ʈ�� ���� �ϴ� ����� ������ ����
        audioSourceSFX = GameObject.Find("SFX").GetComponent<AudioSource>();

        audioSourceBgm.clip = bgm;

        //���ҽ� �������� ������Ʈ�� ã�� �ε�, �̶� �޾ƿ��� ���� ������Ʈ�̹Ƿ�, as Ŭ�������� ���� �ش� �����Ͱ� � ���������� ǥ�����ָ� �� ���·� �޾ƿ��� �ȴ�.
        audioSourceSFX.clip = Resources.Load("Explosion") as AudioClip;

        //���ҽ� �ε� �� ��ΰ� ������ �ִٸ� ������/���ϸ� ���� �ۼ�
        //���ҽ� �ε� �� �ۼ��ϴ� �̸����� Ȯ���ڸ��� �ۼ����� ����
        audioSourceSFX.clip = Resources.Load("Audio/BombCharge") as AudioClip;


        audioSourceBgm.Play(); // ����
        //audioSourceBgm.Pause(); // �Ͻ�����
        //audioSourceBgm.UnPause(); // �Ͻ� ���� ����
        //audioSourceSFX.PlayOneShot(bgm); //Ŭ�� �ϳ��� �Ѽ��� �÷���
        //audioSourceBgm.Stop(); // ��������
        //audioSourceBgm.PlayDelayed(1.0f); // 1�� �ڿ� ���, ����� �����̸� ����
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
