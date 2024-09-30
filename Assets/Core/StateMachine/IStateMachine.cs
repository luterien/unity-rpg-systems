
namespace Madrize.Core.StateMachine
{
    public interface IStateMachine
    {
        /// <summary>
        /// Sets a current state
        /// </summary>
        /// <param name="state"></param>
        bool SetState(State state);
    }
}