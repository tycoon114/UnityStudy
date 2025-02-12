using UnityEngine;
using System;
using UnityEngine.UI;

//delegate를 이용하면 이벤트를 더 쉽게 짤 수 있다.

class MeetEvent {

    public delegate void MeetEventHanfler(string message);
    public event MeetEventHanfler meethandler;

    public void Meet() {
        Debug.Log("듀얼 개시");
    }

}

public class UnityDeleSample : MonoBehaviour
{
    public Text messageUI;
    MeetEvent meetEvent = new MeetEvent();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meetEvent.meethandler += EventMessage;
    }

    private void EventMessage(string message)
    {
        //Debug.Log(message);
        messageUI.text = message;
    }

    public void OnButtonEnter() { 
        meetEvent.Meet();
    
    }
}
