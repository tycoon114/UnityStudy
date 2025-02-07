using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class SoundController : MonoBehaviour
{

    //slider 는 UI
    //자동완성으로 만들어지는 sliderJoint는 RigidBody 물리제어를 받는 게임 오브젝트가 공간에서 선을 따라 미끄러지게 하는 설정을 할때 사용 (미닫이문)
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider MasterVolumeSlider;
    [SerializeField] private Slider BgmVolumeSlider;
    [SerializeField] private Slider SFXVolumeSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        MasterVolumeSlider.onValueChanged.AddListener(SetMaster);
        BgmVolumeSlider.onValueChanged.AddListener(SetBgm);
        SFXVolumeSlider.onValueChanged.AddListener(SetSFX);
    }

    private void SetMaster(float volume)
    {
        //오디오믹서가 가지오 있는 파라미터의 수치를 설정하는 기능
        audioMixer.SetFloat("Master",Mathf.Log10(volume) * 15);

        //자주 사용되는 Mathf함수
        //1. Mathf.Deg2Rad
        // degree(60분법)을 통해 radian(호도법)을 계산 --> 각도 계산, PI / 180, Pi *2/ 360
        //2. Mathf.Rad2Deg 
        // 라디안 값을 디그리 값으로, 360/(pi *2), 1라디안은 약 57도
        //3. Mathf.Abs
        //절대값을 계산해주는 기능
        //4.Mathf.Atan
        //아크 탄젠트 값을 계산
        //5. Mathf.Ceil
        //소수점 올림 계산
        //6 Mathf.Clamp(value,min,max)
        // value를 min과 max 사이의 값으로 고정
        //7 Mathf.log10
        //베이스가 10으로 지정되어있는 수의 로그를 반환해주는 기능

        // 이번 예제에서는 오디오 믹서의 최소 ~ 최대 볼륨 값 때문에 로그 함수 사용
        // 최소가 -80. 최대가 0   그래서 수치 변경시 Mathf.Log10(슬라이더 수치) * 15 를 통해 범위를 설정하고, 슬라이더의 최소값이 0.01일 경우 -80, 1일경우 0이 계산


    }

    private void SetBgm(float volume)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 15);
    }

    private void SetSFX(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 15);
    }


}
