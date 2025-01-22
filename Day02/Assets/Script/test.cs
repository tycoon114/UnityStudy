using Unity.VisualScripting;
using UnityEngine;

//유니티 튜토리얼 영역에서 만들어진 SampleA 클래스
namespace UntityTutorial2 {

    public class SampleA { 
    
    }

}

public class SampleA2 {

 }

/// <summary>
/// 
///유니티 스크립트 예제
/// 
/// </summary>
public class test : MonoBehaviour
//MonoBehaviour는 클래스에 연결했을 경우 유니티씬에 존재하는 오브젝트에 스크립트를 연결 할 수 있게 해준다.
//추가적으로 유니티에서 제공하는 기능을 사용할 때 사용
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
