using UnityEngine;
using System;


class SpecialPortalEvent {

    public event EventHandler kill;

    int count = 0;

    public void Onkill() {
        CountPlus();
        if (count == 5)
        {
            count = 0;
            kill(this, EventArgs.Empty);
        }
        else {
            Debug.Log($"{count} 처리");
        }
        
    }
    public void CountPlus() => count++;

}

public class UEventSample : MonoBehaviour
{
    //1. 이벤트 정의
    SpecialPortalEvent SpecialPortalEvent = new SpecialPortalEvent();

    void Start()
    {
        //이벤트 핸들러의 이벤트 연결
        SpecialPortalEvent.kill += new EventHandler(MonsterKill);
        for (int i = 0; i < 5; i++) { 
            SpecialPortalEvent.Onkill();
        }
    
    }
    //이벤트 발생 시 실행코드
    private void MonsterKill(object sender, EventArgs e)
    {
        Debug.Log("포탈 생성");
    }
}
