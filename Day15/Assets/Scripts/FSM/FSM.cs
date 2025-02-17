using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class FSM
{

    private NpcNatsuState _npcState;
    public FSM(NpcNatsuState initState)
    {
        _npcState = initState;
        ChangeState(_npcState);
    }

    public void ChangeState(NpcNatsuState nextState)
    {
        if (nextState == _npcState)
            return;

        if (_npcState != null)
        {
            _npcState.OnStateEnd();
        }

        _npcState = nextState;
        _npcState.OnStateStart();
    }

    public void UpdateState()
    {
        _npcState?.OnStateUpdate();
    }
}
