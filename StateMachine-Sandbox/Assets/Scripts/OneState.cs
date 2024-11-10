using StateMachine.Runtime;
using UnityEngine;

public class OneState : BaseState<MachineRunner>
{
    private float _countDown;
    
    public override void OnEnter()
    {
        Owner.SetText("OneState");
        _countDown = 3f;
        Debug.Log("Entering OneState");
    }

    public override void OnExit()
    {
        Debug.Log("Exiting OneState");
    }

    public override void OnTick(float deltaTime)
    {
        _countDown -= deltaTime;
        if (_countDown < 0)
            SwitchState<TwoState>();
    }
}