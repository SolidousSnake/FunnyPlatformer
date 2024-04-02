using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Code.Runtime.Core.States
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IState> _registeredStates;
        private IState _activeState;
        private IUpdateableState _updateableState;
        
        public StateMachine()
        {
            _registeredStates = new Dictionary<Type, IState>();
        }
        
        public void RegisterState(IState state) 
        {
            _registeredStates.Add(state.GetType(), state);
        }

        public void Enter<T>() where T : class, IState
        {
            IState state = ChangeState<T>();
            state.Enter();
        }

        private T ChangeState<T>() where T : class, IState
        {
            _activeState?.Exit();
            T state = GetState<T>();
            _activeState = state;

            if (_activeState is IUpdateableState updateableState)
                _updateableState = updateableState;
            else
                _updateableState = null;
            
            return state;
        }

        public void Update()
        {
            _updateableState?.Update();
        }
        
        private T GetState<T>() where T : class, IState => _registeredStates[typeof(T)] as T;
    }
}