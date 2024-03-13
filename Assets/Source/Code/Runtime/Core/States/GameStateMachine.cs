using System.Collections.Generic;
using Source.Code.Runtime.Core.Interfaces;

namespace Source.Code.Runtime.Core.States
{
    public sealed class GameStateMachine : StateMachine
    {
        public GameStateMachine(IReadOnlyList<IState> states) : base(states)
        {
            
        }
    }
}