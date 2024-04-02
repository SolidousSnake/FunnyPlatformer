using NaughtyAttributes;
using Source.Code.Runtime.MV.Health;
using Source.Code.Runtime.MV.Wallet;
using Source.Code.Runtime.Unit.Jumper;
using Source.Code.Runtime.Unit.Mover;
using Source.Code.Runtime.Unit.Rotator;
using Source.Code.Runtime.Config;
using Source.Code.Runtime.Core.Utils;
using Source.Code.Runtime.Services.CameraService;
using Source.Code.Runtime.Services.InputService;
using Source.Code.Runtime.Triggers;
using UnityEngine;
using VContainer;

namespace Source.Code.Runtime.Unit
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PlayerFacade : MonoBehaviour
    {
        [Foldout("Components")] [SerializeField] private Animator _animator;
        [Foldout("Components")] [SerializeField] private Rigidbody2D _rigidBody2D;
        [Foldout("Components")] [SerializeField] private Health _health;
        [Foldout("Components")] [SerializeField] private SurroundingsTrigger _groundTrigger;
        [Foldout("Components")] [SerializeField] private SurroundingsTrigger _wallTrigger;

        private IInputService _inputService;
        private IJumper _jumper;
        private PhysicsMovement _physicsMovement;
        private HorizontalRotator _rotator;

        private float _magnitudeValue;

        public Health Health => _health;
        public Wallet Wallet { get; private set; }

        private void OnValidate()
        {
            _rigidBody2D ??= GetComponent<Rigidbody2D>();
        }

        [Inject]
        private void Construct(WalletView walletView, HealthView healthView, PlayerConfig config
            , CameraService cameraService, IInputService inputService)
        {
            _inputService = inputService;
            _magnitudeValue = config.MovementSpeed;
            
            _physicsMovement = new PhysicsMovement(_rigidBody2D, config.MovementSpeed, _wallTrigger);
            _jumper = new PhysicJumper(_rigidBody2D, config.JumpHeight, _groundTrigger);
            _rotator = new HorizontalRotator(transform);
            Wallet = new Wallet(walletView);

            _health.Initialize(config.Health);
            healthView.Initialize(_health);

            Subscribe();
            cameraService.SetTarget(transform);
        }

        private void Update()
        {
            _animator.SetBool(Constants.Animation.Move, _rigidBody2D.velocity.magnitude >= _magnitudeValue);
            _animator.SetBool(Constants.Animation.Jump, _groundTrigger.Triggered() == false);
        }

        private void Subscribe()
        {
            _inputService.MovementButtonPressing += _physicsMovement.Move;
            _inputService.MovementButtonPressing += _rotator.Rotate;
            _inputService.MovementButtonReleased += _physicsMovement.ResetVelocity;

            _inputService.JumpButtonPressed += _jumper.Jump;
        }

        private void OnDestroy()
        {
            _inputService.MovementButtonPressing -= _physicsMovement.Move;
            _inputService.MovementButtonPressing -= _rotator.Rotate;
            _inputService.MovementButtonReleased -= _physicsMovement.ResetVelocity;

            _inputService.JumpButtonPressed -= _jumper.Jump;
        }
    }
}