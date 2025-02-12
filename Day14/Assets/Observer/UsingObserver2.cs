using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingObserver2 : MonoBehaviour ,ISubject
{
    List<NewObserver> observers = new List<NewObserver>();

    public void Add(NewObserver observer)
    {
        observers.Add(observer);    
    }

    public void Notify()
    {
        foreach (var observer in observers) { 
            observer.OnNotify();
        }
    }

    public void Remove(NewObserver observer)
    {
        if (observers.Count > 0)
        {
            observers.Remove(observer);
        }
    }

    private void Start()
    {
        var observer1 = new Observer1();
        var observer2 = new Observer2();

        Add(observer1); 
        Add(observer2);
    }
}

