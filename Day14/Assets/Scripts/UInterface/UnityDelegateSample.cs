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


        //대리자의 경우 바로 기능을 구현해서 사용하는 것도 가능

        func01 = () => 10;
        //생성 방법
        //Func<T> 이름  = (매개변수 작성 위치) => 값;
        Func<int> test = () => 10;

        //매개변수가 존재하는 경우
        func02 = (a, b) => a + b;

        //식을 여러개 적을 경우
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
