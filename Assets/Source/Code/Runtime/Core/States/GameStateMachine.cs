using System.Collections.Generic;

namespace Source.Code.Runtime.Core.States
{
    public sealed class GameStateMachine : StateMachine
    {
        public void RegisterStates(IReadOnlyList<IState> states)
        {
            foreach (var state in states)
                RegisterState(state);
        }
    }
}