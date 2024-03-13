using NaughtyAttributes;
using Source.Code.Runtime.Core.States;
using UnityEngine;
using VContainer;

namespace Source.Code.Runtime.Triggers
{
    public class FinishTrigger : MonoBehaviour
    {
        [SerializeField, Layer] private int _targetLayer;

        private GameStateMachine _stateMachine;

        [Inject]
        private void Construct(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.layer == _targetLayer) 
            {
                _stateMachine.SetState<VictoryState>();
            }
        }
    }
}