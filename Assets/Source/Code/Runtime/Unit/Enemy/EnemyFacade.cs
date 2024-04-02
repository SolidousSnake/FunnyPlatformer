using NaughtyAttributes;
using Source.Code.Runtime.Config;
using Source.Code.Runtime.Core.States;
using Source.Code.Runtime.Unit.Enemy.States;
using Source.Code.Runtime.Unit.Enemy.Vision;
using Source.Code.Runtime.Weapon;
using UnityEngine;
using TNRD;

namespace Source.Code.Runtime.Unit.Enemy
{
    public class EnemyFacade : MonoBehaviour
    {
        [Foldout("Speech")] [SerializeField] private AudioSource _source;
        [Foldout("Speech")] [SerializeField] private QuotesConfig _idleQuotes;
        [Foldout("Speech")] [SerializeField] private QuotesConfig _playerSightedQuotes;
        [Foldout("Speech")] [SerializeField] private QuotesConfig _playerFleedQuotes;
        [Foldout("Speech")] [SerializeField] private float _speechDelay;
        
        [Foldout("Components")] [SerializeField] private SerializableInterface<IVision> _vision;
        [Foldout("Components")] [SerializeField] private SerializableInterface<IWeapon> _weapon;

        private StateMachine _stateMachine;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            _stateMachine = new StateMachine();
            
            var enemySpeaker = new EnemySpeaker(_source);
            
            _stateMachine.RegisterState(new IdleState(enemySpeaker, _idleQuotes, _speechDelay));
            _stateMachine.RegisterState(new AttackState(enemySpeaker, _playerSightedQuotes, _playerFleedQuotes, _weapon.Value));
            
            _stateMachine.Enter<IdleState>();
        }

        private void OnEnable()
        {
            _vision.Value.PlayerSighted += EnterAttackState;
            _vision.Value.PlayerFleed += EnterIdleState;
        }

        private void OnDisable()
        {
            _vision.Value.PlayerSighted -= EnterAttackState;
            _vision.Value.PlayerFleed -= EnterIdleState;
        }

        private void Update() => _stateMachine.Update();

        private void EnterIdleState() => _stateMachine.Enter<IdleState>();
        private void EnterAttackState() => _stateMachine.Enter<AttackState>();
    }
}