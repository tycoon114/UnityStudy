using UnityEngine;

public class DataSample : MonoBehaviour
{

    // 유니티 데이터의 저장

    //일반적인 작업 시, 플레이 하는 경우에만 점수 등이 설정되고 다시 플레이 할 경우 기존 기록들이 제거됨

    //게임 여부에 따라 플레이어의 기본 정보를 가지고 진행하는 게임도 존재

    //PlayerPrefs  주로 플레이어에 대한 환경 설정읠 저장 할때 사용되는 클래스
    //해당 클래스는 문자열, 실수 ,정수를 사용자의 플랫폼 레지스트리에 저장

    //PlayerPerfs는 키쌍값으로 구성되있는 데이터 (Dictionary)

    public UserData userData;
    //1 데이터는 유니티 에디터에서 작성
    //2. 레지스트리에 있는 키값 사용해서 검색
    //3. 키 전체 삭제
    private void Start()
    {
        //PlayerPrefs.SetString("id",userData.userId);
        //PlayerPrefs.SetString("userName", userData.userName);
        //PlayerPrefs.SetString("password", userData.userPassword);
        //PlayerPrefs.SetString("email", userData.userEmail);

        //Debug.Log(PlayerPrefs.GetString("id"));

        //PlayerPrefs.DeleteAll();
        //Debug.Log("data Deleted");

    }




}
