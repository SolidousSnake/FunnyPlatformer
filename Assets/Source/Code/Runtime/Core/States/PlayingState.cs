using Source.Code.Runtime.Core.Interfaces;
using Source.Code.Runtime.Core.States.View;

namespace Source.Code.Runtime.Core.States
{
    public sealed class PlayingState : IState
    {
        private readonly PlayingStateView _stateView;
        
        public PlayingState(PlayingStateView stateView)
        {
            _stateView = stateView;
        }
        
        public void Enter()
        {
            _stateView.gameObject.SetActive(true);
        }

        public void Exit()
        {
            _stateView.gameObject.SetActive(false);
        }
    }
}