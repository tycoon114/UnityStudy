using UnityEngine;

//클래스에 대한 직렬화
[System.Serializable]
public class UserData
{
    public string userId;
    public string userName;
    public string userPassword;
    public string userEmail;

    public UserData() { 
    
    }


    //생성자
    //클래스 이름과 동일한 메소드
    //반환이 따로 없음
    //별도로 설정 하지 않은 경우 기본 생성자로 처리됨

    //기본 생성자 - 클래스 이름과 동일한 메소드, 매개 변수가 따로 존재하지 않음

    //기본정보를 작성하면 생성 할 수 있는 유저 데이터  [생성자]
    public UserData(string userId, string userName, string userPassword, string userEmail)
    {
        this.userId = userId;
        this.userName = userName;
        this.userPassword = userPassword;
        this.userEmail = userEmail;
    }
    /// <summary>
    /// 데이터를 하나의 문자열로 리턴ㅇ
    /// </summary>
    /// <returns>아이디,이름.비번.이메일 </returns>
    public string DataGet() => $"{userId},{userName},{userPassword},{userEmail}";

    /// <summary>
    /// 데이터에대한 정보를 전달받고 Userdata로 리턴
    /// </summary>
    /// <param name="data">아이디, 이름.비번,이메일</param>
    /// <returns></returns>
    public static UserData DataSet(string data) {

        string[] data_value = data.Split(',');

        return new UserData(data_value[0], data_value[1], data_value[2], data_value[3]);
    }

}
