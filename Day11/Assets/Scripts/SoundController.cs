using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class SoundController : MonoBehaviour
{

    //slider �� UI
    //�ڵ��ϼ����� ��������� sliderJoint�� RigidBody ������� �޴� ���� ������Ʈ�� �������� ���� ���� �̲������� �ϴ� ������ �Ҷ� ��� (�̴��̹�)
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
        //������ͼ��� ������ �ִ� �Ķ������ ��ġ�� �����ϴ� ���
        audioMixer.SetFloat("Master",Mathf.Log10(volume) * 15);

        //���� ���Ǵ� Mathf�Լ�
        //1. Mathf.Deg2Rad
        // degree(60�й�)�� ���� radian(ȣ����)�� ��� --> ���� ���, PI / 180, Pi *2/ 360
        //2. Mathf.Rad2Deg 
        // ���� ���� ��׸� ������, 360/(pi *2), 1������ �� 57��
        //3. Mathf.Abs
        //���밪�� ������ִ� ���
        //4.Mathf.Atan
        //��ũ ź��Ʈ ���� ���
        //5. Mathf.Ceil
        //�Ҽ��� �ø� ���
        //6 Mathf.Clamp(value,min,max)
        // value�� min�� max ������ ������ ����
        //7 Mathf.log10
        //���̽��� 10���� �����Ǿ��ִ� ���� �α׸� ��ȯ���ִ� ���

        // �̹� ���������� ����� �ͼ��� �ּ� ~ �ִ� ���� �� ������ �α� �Լ� ���
        // �ּҰ� -80. �ִ밡 0   �׷��� ��ġ ����� Mathf.Log10(�����̴� ��ġ) * 15 �� ���� ������ �����ϰ�, �����̴��� �ּҰ��� 0.01�� ��� -80, 1�ϰ�� 0�� ���


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
