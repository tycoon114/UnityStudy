using UnityEngine;

public class DeligateSample : MonoBehaviour
{

    delegate void DelegateTest();
    delegate string DelegateText(float x);
    delegate int DelegateInt(int x, int y);


    void Start()
    {
        //델리게이트 사용
        //델리게이트명 변수명 = new 델리게이트명(함수명);
        DelegateTest dt = new DelegateTest(Attack);

        //함수 처럼 호출
        dt();

        //내용 변경
        //변수명 = 함수명;
        dt = Guard;
        dt();

        dt += Attack;
        dt += Attack;
        dt += Attack;
        dt();
    }


    void UseDelegete(DelegateTest dt){
        dt();
     }

    DelegateTest Selection(int value) { 
        if(value == 1) return Attack;
        else  if (value == 2) return Guard;
        else return MoveLeft;
    }


    void Attack() =>  Debug.Log("공격");
    void Guard() => Debug.Log("방어");
    void MoveLeft() => Debug.Log("왼쪽 이동");

}
