using NTC.Pool;
using Source.Code.Runtime.Core.States;
using VContainer.Unity;

namespace Source.Code.Runtime.Core.Bootstrapper
{
    public sealed class Bootstrapper : IStartable
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PoolsPreset _preset;
        
        public Bootstrapper(GameStateMachine stateMachine, PoolsPreset preset)
        {
            _stateMachine = stateMachine;
            _preset = preset;
        }
        
        public void Start()
        {
            _stateMachine.SetState<PrepearingState>();
        }
    }
}