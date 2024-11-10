using System;
using System.Collections.Generic;

namespace StateMachine.Runtime
{
    public class StateMachine<TOwner>
    {
        private readonly Dictionary<Type, IState> _states = new();
        
        public IState CurState { get; private set; }
        public TOwner Owner { get; }
        
        public StateMachine(TOwner owner)
        {
            Owner = owner;
        }

        public void OnTick(float deltaTime)
        {
            CurState?.OnTick(deltaTime);
        }

        public void SwitchState<TState>() where TState : BaseState<TOwner>, new()
        {
            if (CurState != null && CurState.GetType() == typeof(TState))
                return;

            TState state = GetOrCreateState<TState>();
            if (state == null)
                return;
            
            CurState?.OnExit();
            CurState = state;
            CurState.OnEnter();
        }

        private TState GetOrCreateState<TState>() where TState : BaseState<TOwner>, new()
        {
            if (_states.TryGetValue(typeof(TState), out IState state))
                return (TState)state;
            
            TState newState = new TState();
            newState.Init(this);
            _states.Add(typeof(TState), newState);
            return newState;
        }
    }
}
