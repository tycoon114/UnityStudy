using UnityEngine;

public class DeligateSample : MonoBehaviour
{

    delegate void DelegateTest();
    delegate string DelegateText(float x);
    delegate int DelegateInt(int x, int y);


    void Start()
    {
        //��������Ʈ ���
        //��������Ʈ�� ������ = new ��������Ʈ��(�Լ���);
        DelegateTest dt = new DelegateTest(Attack);

        //�Լ� ó�� ȣ��
        dt();

        //���� ����
        //������ = �Լ���;
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


    void Attack() =>  Debug.Log("����");
    void Guard() => Debug.Log("���");
    void MoveLeft() => Debug.Log("���� �̵�");

}
