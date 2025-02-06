using UnityEngine;

public class UserDataSystem : MonoBehaviour
{

    public UserData userData1;
    public UserData userData2;


    //PlayerPrefs 기능
    // deleteAll() 전체 삭제
    // DeleteKey(키) 키에 해당하는 값  삭제
    // GetString, int, float  해당값 가져오기 
    //Set..... 해당값 설정 
    //HasKey(키) 해당 키가 존재하는지 확인
    //

    private void Start()
    {
        userData1 = new UserData();

        userData2 = new UserData("asdff", "aaaa", "asdf1","kaskdaskd");

        string data_vaue = userData2.DataGet();
        Debug.Log(data_vaue);

        PlayerPrefs.SetString("Data01", data_vaue);
        PlayerPrefs.Save();


        userData1 = UserData.DataSet(data_vaue);

        Debug.Log(userData1.DataGet());


    }

}
