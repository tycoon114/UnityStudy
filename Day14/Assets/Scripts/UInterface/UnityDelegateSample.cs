using UnityEngine;
using System;
public class UnityDelegateSample : MonoBehaviour
{

    Action action;

    Action<int> action1;

    Func<int> func01;

    Func<int, int, int> func02;

    void Start()
    {
        action = Sample;
        action();
        action1 = Sample1;


        //�븮���� ��� �ٷ� ����� �����ؼ� ����ϴ� �͵� ����

        func01 = () => 10;
        //���� ���
        //Func<T> �̸�  = (�Ű����� �ۼ� ��ġ) => ��;
        Func<int> test = () => 10;

        //�Ű������� �����ϴ� ���
        func02 = (a, b) => a + b;

        //���� ������ ���� ���
        func02 = (a,b) =>
        {
            if (a > b) {
                a = b;
            }
            return a;
        };

    }

    public void Sample() { }

    public void Sample1(int a) { }

    public int Sample2() { return 0; }
}
