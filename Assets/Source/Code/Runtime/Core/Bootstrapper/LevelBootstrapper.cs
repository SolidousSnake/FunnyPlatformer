using System.Collections.Generic;
using Source.Code.Runtime.Core.States;
using VContainer.Unity;

namespace Source.Code.Runtime.Core.Bootstrapper
{
    public sealed class LevelBootstrapper : IStartable
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IReadOnlyList<IState> _states;

        public LevelBootstrapper(GameStateMachine stateMachine, IReadOnlyList<IState> states)
        {
            _stateMachine = stateMachine;
            _states = states;
        }
        
        public void Start()
        {
            _stateMachine.RegisterStates(_states);
            _stateMachine.Enter<PreparingState>();
        }
    }
}