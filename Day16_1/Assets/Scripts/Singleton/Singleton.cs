using UnityEngine;


public class Tester : MonoBehaviour {
    int point = 0;

    private void Start()
    {
        point = Singleton.Instance.point; //싱글톤에 있는 프로퍼티

        Singleton.Instance.PointPlus(); // 또는 메소드를 통해 클래스 내부의 객체가 가지고 있는 정보를 사용할 수 있다.


    }

}


public class Singleton : MonoBehaviour
{
    //자기 자신에 대한 인스턴스 생성. 인스턴스 이면서 전역으로 접근 가능
    private static Singleton _instance;

    //클래스 내부에 표현할 값을 설계

    public int point = 0;
    public void PointPlus() { 
        point++;

    }


    public void ViewPoint() {
        Debug.Log(" 현재 "+point);
    }

    //메소드를 통해서 전달
    public static Singleton GetInstance()
    {
        //값이 비어있으면
        if (_instance == null)
        {
            //새롭게 할당
            _instance = new Singleton();
        }
        //일반적안 경우라면 현재의 인스턴스를 리턴
        return _instance;
    }

    //프로퍼티로 설계할 경우
    public static Singleton Instance
    {
        get
        {
            //값이 비어있으면
            if (_instance == null)
            {
                //새롭게 할당
                _instance = new Singleton();
            }
            //일반적안 경우라면 현재의 인스턴스를 리턴
            return _instance;
        }
    }


}
