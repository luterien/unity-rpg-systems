
namespace Madrize.Core.StateMachine
{
    abstract public class StateMachine : IStateMachine
    {
        public State _currentState;

        public void OnTick(float deltaTime)
        {
            _currentState.OnTick(deltaTime);
        }

        public bool SetState(State state)
        {
            if (state == _currentState)
            {
                return false;
            }

            if (_currentState != null)
            {
                _currentState.OnExit();
            }

            _currentState = state;
            _currentState.SetStateMachine(this);
            _currentState.OnEnter();

            return true;
        }
    }
}