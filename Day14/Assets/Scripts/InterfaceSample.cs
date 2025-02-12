using UnityEngine;

//유니티 인터페이스

public interface ICountAble { 
    int Count { get; set; }

    void CountPlus();
}



//인터페이스는 상속처럼 등록 가능, 다중 상속도 가능
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
                Debug.Log("최대치는 99개 입니다");
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
        Debug.Log($"{posionName}을/를 사용했습니다");
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
        //클래스 사용
        postion.Count = 99;
        postion.PosionName = "빨간포션";
        postion.CountPlus();
        postion.Use();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

