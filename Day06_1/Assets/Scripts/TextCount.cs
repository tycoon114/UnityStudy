using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextCount : MonoBehaviour
{

    public Text countText;

    public int count = 1;

    void Start()
    {
        //코루틴 사용 방법
        //StartCoroutine("함수 이름 ( IEnumertator 형태의 함수)")
        // 1. 문자열을 통해 해당 함수를 찾아서 실행
        // 오타가 있어도 오류가 발생하지 않음

        //해당 코루틴 중지 제어 가능
        StartCoroutine("CountPlus");
        //StopCoroutine("CountPlus");

        // 2. 해당 함수를 호출해 실행 결과를 반환받는 형태, 오타 발생시 오류 체크 가능
        //함수 형태 실행 방식, 이 방식으로는 StopCoroutine 을 통한 외부에서의 중지기능을 사용 할 수 없다
        //StartCoroutine(CountPlus());


    }

    IEnumerator CountPlus() 
    {

        while (true) {
            count++;
            countText.text = count.ToString("N0");
            //N0는 숫자3자리 간격으로 , 를 표시하는 포맷
            yield return null;

        }

        /*        Debug.Log("AAAA");

                yield return new WaitForSeconds(1);
                //yeild 는 일시적으로 CPU의 권한을 다른함수에 위임하는 키워드
                Debug.Log("BBBB");
                yield return new WaitForSeconds(5);
                Debug.Log("CCCC");
        */



    }

}
