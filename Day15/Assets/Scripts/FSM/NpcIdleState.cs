using UnityEngine;

public class NpcIdleState : NpcNatsuState
{
    private Npc _npc;


    public NpcIdleState(Npc npc) : base(npc)
    {
        _npc = npc;
    }

    public override void OnStateEnd()
    {
    }

    public override void OnStateStart()
    {
    }

    public override void OnStateUpdate()
    {
    }
}
