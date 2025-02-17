using UnityEngine;

public abstract class NpcNatsuState
{
    private NpcNatsu _npcNatsu;

    protected NpcNatsuState(NpcNatsu npcNatsu)
    { 
        _npcNatsu = npcNatsu;
    }

    // ���¿� ������ �� �ѹ� ����
    public abstract void OnStateStart();
    // ���¿� ���� �� ��� ����
    public abstract void OnStateUpdate();
    // ���¸� �������� �� �ѹ� ����
    public abstract void OnStateEnd();
}
