using UnityEngine;

public class NpcNatsu : MonoBehaviour
{

    private enum NatsuStateEnum
    { 
        Idle
    }

    private NatsuStateEnum _state;

    void Start()
    {
        _state = NatsuStateEnum.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state) 
        { 
            case NatsuStateEnum.Idle:
                break;
            default:
                break;
        }
    }
}
