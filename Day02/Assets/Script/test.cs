using Unity.VisualScripting;
using UnityEngine;

//����Ƽ Ʃ�丮�� �������� ������� SampleA Ŭ����
namespace UntityTutorial2 {

    public class SampleA { 
    
    }

}

public class SampleA2 {

 }

/// <summary>
/// 
///����Ƽ ��ũ��Ʈ ����
/// 
/// </summary>
public class test : MonoBehaviour
//MonoBehaviour�� Ŭ������ �������� ��� ����Ƽ���� �����ϴ� ������Ʈ�� ��ũ��Ʈ�� ���� �� �� �ְ� ���ش�.
//�߰������� ����Ƽ���� �����ϴ� ����� ����� �� ���
{

    //public float speed = 5.0f;
    //public float temp = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("asdf");
    }

    int count = 0;

    // Update is called once per frame
    void Update()
    {
 

        if (count <= 100) {
            Debug.Log($"{count}");
            count++;
        }
    }
}
