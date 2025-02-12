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
            Debug.Log($"{count} ó��");
        }
        
    }
    public void CountPlus() => count++;

}

public class UEventSample : MonoBehaviour
{
    //1. �̺�Ʈ ����
    SpecialPortalEvent SpecialPortalEvent = new SpecialPortalEvent();

    void Start()
    {
        //�̺�Ʈ �ڵ鷯�� �̺�Ʈ ����
        SpecialPortalEvent.kill += new EventHandler(MonsterKill);
        for (int i = 0; i < 5; i++) { 
            SpecialPortalEvent.Onkill();
        }
    
    }
    //�̺�Ʈ �߻� �� �����ڵ�
    private void MonsterKill(object sender, EventArgs e)
    {
        Debug.Log("��Ż ����");
    }
}
