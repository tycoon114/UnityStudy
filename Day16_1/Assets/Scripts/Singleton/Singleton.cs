using UnityEngine;


public class Tester : MonoBehaviour {
    int point = 0;

    private void Start()
    {
        point = Singleton.Instance.point; //�̱��濡 �ִ� ������Ƽ

        Singleton.Instance.PointPlus(); // �Ǵ� �޼ҵ带 ���� Ŭ���� ������ ��ü�� ������ �ִ� ������ ����� �� �ִ�.


    }

}


public class Singleton : MonoBehaviour
{
    //�ڱ� �ڽſ� ���� �ν��Ͻ� ����. �ν��Ͻ� �̸鼭 �������� ���� ����
    private static Singleton _instance;

    //Ŭ���� ���ο� ǥ���� ���� ����

    public int point = 0;
    public void PointPlus() { 
        point++;

    }


    public void ViewPoint() {
        Debug.Log(" ���� "+point);
    }

    //�޼ҵ带 ���ؼ� ����
    public static Singleton GetInstance()
    {
        //���� ���������
        if (_instance == null)
        {
            //���Ӱ� �Ҵ�
            _instance = new Singleton();
        }
        //�Ϲ����� ����� ������ �ν��Ͻ��� ����
        return _instance;
    }

    //������Ƽ�� ������ ���
    public static Singleton Instance
    {
        get
        {
            //���� ���������
            if (_instance == null)
            {
                //���Ӱ� �Ҵ�
                _instance = new Singleton();
            }
            //�Ϲ����� ����� ������ �ν��Ͻ��� ����
            return _instance;
        }
    }


}
