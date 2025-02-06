using UnityEngine;

//Ŭ������ ���� ����ȭ
[System.Serializable]
public class UserData
{
    public string userId;
    public string userName;
    public string userPassword;
    public string userEmail;

    public UserData() { 
    
    }


    //������
    //Ŭ���� �̸��� ������ �޼ҵ�
    //��ȯ�� ���� ����
    //������ ���� ���� ���� ��� �⺻ �����ڷ� ó����

    //�⺻ ������ - Ŭ���� �̸��� ������ �޼ҵ�, �Ű� ������ ���� �������� ����

    //�⺻������ �ۼ��ϸ� ���� �� �� �ִ� ���� ������  [������]
    public UserData(string userId, string userName, string userPassword, string userEmail)
    {
        this.userId = userId;
        this.userName = userName;
        this.userPassword = userPassword;
        this.userEmail = userEmail;
    }
    /// <summary>
    /// �����͸� �ϳ��� ���ڿ��� ���Ϥ�
    /// </summary>
    /// <returns>���̵�,�̸�.���.�̸��� </returns>
    public string DataGet() => $"{userId},{userName},{userPassword},{userEmail}";

    /// <summary>
    /// �����Ϳ����� ������ ���޹ް� Userdata�� ����
    /// </summary>
    /// <param name="data">���̵�, �̸�.���,�̸���</param>
    /// <returns></returns>
    public static UserData DataSet(string data) {

        string[] data_value = data.Split(',');

        return new UserData(data_value[0], data_value[1], data_value[2], data_value[3]);
    }

}
