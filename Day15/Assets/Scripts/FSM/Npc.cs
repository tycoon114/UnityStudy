using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Npc : NpcNatsu
{

    private enum NpcStateEnum
    {
        IDLE
    }

    private NpcStateEnum _currentState;
    private FSM _fsm;

    void Start()
    {
        _currentState = NpcStateEnum.IDLE;
        _fsm = new FSM(new NpcIdleState(this));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
