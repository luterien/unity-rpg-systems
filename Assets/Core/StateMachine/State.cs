using System;

namespace Madrize.Core.StateMachine
{
    public abstract class State
    {
        public event Action OnStateComplete;

        /// <summary>
        /// Reference of current State Machine
        /// </summary>
        protected IStateMachine StateMachine;

        /// <summary>
        /// Sets a state machine
        /// </summary>
        /// <param name="stateMachine"></param>
        public void SetStateMachine(IStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        /// <summary>
        /// Called on state Initialization
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public abstract void OnEnter();

        /// <summary>
        /// Called on Update
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public virtual void OnTick(float deltaTime) { }

        /// <summary>
        /// Called when exiting state
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public virtual void OnExit() { }

        protected void SetStateComplete()
        {
            OnStateComplete?.Invoke();
        }
    }
}