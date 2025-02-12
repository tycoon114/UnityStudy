using UnityEngine;
using System;
using UnityEngine.UI;

//delegate�� �̿��ϸ� �̺�Ʈ�� �� ���� © �� �ִ�.

class MeetEvent {

    public delegate void MeetEventHanfler(string message);
    public event MeetEventHanfler meethandler;

    public void Meet() {
        Debug.Log("��� ����");
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
