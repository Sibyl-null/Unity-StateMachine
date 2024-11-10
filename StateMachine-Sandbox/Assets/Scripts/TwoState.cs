using StateMachine.Runtime;
using UnityEngine;

public class TwoState : BaseState<MachineRunner>
{
    public override void OnEnter()
    {
        Owner.SetText("TwoState");
        Debug.Log("Entering TwoState");
    }

    public override void OnExit()
    {
        Debug.Log("Exiting TwoState");
    }

    public override void OnTick(float deltaTime)
    {
    }
}