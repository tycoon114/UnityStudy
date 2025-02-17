using UnityEngine;

public abstract class NpcNatsuState
{
    private NpcNatsu _npcNatsu;

    protected NpcNatsuState(NpcNatsu npcNatsu)
    { 
        _npcNatsu = npcNatsu;
    }

    // 상태에 들어왔을 때 한번 실행
    public abstract void OnStateStart();
    // 상태에 있을 때 계속 실행
    public abstract void OnStateUpdate();
    // 상태를 빠져나갈 때 한번 실행
    public abstract void OnStateEnd();
}
