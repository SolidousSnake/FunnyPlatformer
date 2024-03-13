using System;
using System.Collections.Generic;
using Source.Code.Runtime.Core.Interfaces;

namespace Source.Code.Runtime.Core.States
{
    public abstract class StateMachine
    {
        private readonly Dictionary<Type, IState> _registeredStates;
        private IState _activeState;
        
        public StateMachine(IReadOnlyList<IState> states)
        {
            _registeredStates = new Dictionary<Type, IState>();

            foreach (var state in states)
            {
                RegisterState(state);
            }
        }
        
        public void RegisterState(IState state) 
        {
            _registeredStates.Add(state.GetType(), state);
        }

        public void SetState<T>() where T : IState
        {
            var type = typeof(T);

            if (_activeState != null && _activeState.GetType() == type)
                return;

            if(_registeredStates.TryGetValue(type, out var newState))
            {
                _activeState?.Exit();
                _activeState = newState;
                _activeState?.Enter();
            }
        }
    }
}