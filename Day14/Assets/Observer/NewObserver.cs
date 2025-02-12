using UnityEngine;


//옵저버에 대한 관리, 활용을 위한 인터페이스
public interface ISubject{
    //옵저버 등록
    void Add(NewObserver observer);
    //옵저버 제거
    void Remove(NewObserver observer);
    //갱신
    void Notify();
}


public abstract class NewObserver
{

    public abstract void OnNotify();

}

public class Observer1 : NewObserver
{
    public override void OnNotify() {
        Debug.Log("옵저버1");
    }

}


public class Observer2 : NewObserver
{
    public override void OnNotify()
    {
        Debug.Log("옵저버2");
    }

}