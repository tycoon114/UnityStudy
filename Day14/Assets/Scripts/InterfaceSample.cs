using UnityEngine;

//����Ƽ �������̽�

public interface ICountAble { 
    int Count { get; set; }

    void CountPlus();
}



//�������̽��� ���ó�� ��� ����, ���� ��ӵ� ����
class Postion : Item, ICountAble, IUseAble
{

    public int count;
    private string posionName;


    public int Count { 
        get { 
        return count;
        }
        set {
            if (count > 99) {
                Debug.Log("�ִ�ġ�� 99�� �Դϴ�");
                count = 99;
            }
            count = value;
        }
    }

    public string PosionName { get => posionName; set => posionName = value; }

    public void CountPlus()
    {
        Count++;
    }

    public void Use()
    {
        Debug.Log($"{posionName}��/�� ����߽��ϴ�");
        Count--;
    }
}


public interface IUseAble {
    
    void Use();
}

public class InterfaceSample : MonoBehaviour
{
    Postion postion = new Postion(); 
    
    void Start()
    {
        //Ŭ���� ���
        postion.Count = 99;
        postion.PosionName = "��������";
        postion.CountPlus();
        postion.Use();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

