using UnityEngine;

public class DataSample : MonoBehaviour
{

    // ����Ƽ �������� ����

    //�Ϲ����� �۾� ��, �÷��� �ϴ� ��쿡�� ���� ���� �����ǰ� �ٽ� �÷��� �� ��� ���� ��ϵ��� ���ŵ�

    //���� ���ο� ���� �÷��̾��� �⺻ ������ ������ �����ϴ� ���ӵ� ����

    //PlayerPrefs  �ַ� �÷��̾ ���� ȯ�� ������ ���� �Ҷ� ���Ǵ� Ŭ����
    //�ش� Ŭ������ ���ڿ�, �Ǽ� ,������ ������� �÷��� ������Ʈ���� ����

    //PlayerPerfs�� Ű�ְ����� �������ִ� ������ (Dictionary)

    public UserData userData;
    //1 �����ʹ� ����Ƽ �����Ϳ��� �ۼ�
    //2. ������Ʈ���� �ִ� Ű�� ����ؼ� �˻�
    //3. Ű ��ü ����
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
