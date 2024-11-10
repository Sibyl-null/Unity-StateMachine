namespace StateMachine.Runtime
{
    public interface IState
    {
        void OnEnter();
        void OnExit();
        void OnTick(float deltaTime);
    }
    
    public abstract class BaseState<TOwner> : IState
    {
        private StateMachine<TOwner> _stateMachine;

        protected TOwner Owner => _stateMachine.Owner;
        protected IState CurState => _stateMachine.CurState;

        public void Init(StateMachine<TOwner> stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public abstract void OnEnter();
        public abstract void OnExit();
        public abstract void OnTick(float deltaTime);

        protected void SwitchState<TState>() where TState : BaseState<TOwner>, new()
        {
            _stateMachine.SwitchState<TState>();
        }
    }
}
