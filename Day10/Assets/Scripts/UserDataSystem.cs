using UnityEngine;

public class UserDataSystem : MonoBehaviour
{

    public UserData userData1;
    public UserData userData2;


    //PlayerPrefs ���
    // deleteAll() ��ü ����
    // DeleteKey(Ű) Ű�� �ش��ϴ� ��  ����
    // GetString, int, float  �ش簪 �������� 
    //Set..... �ش簪 ���� 
    //HasKey(Ű) �ش� Ű�� �����ϴ��� Ȯ��
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
