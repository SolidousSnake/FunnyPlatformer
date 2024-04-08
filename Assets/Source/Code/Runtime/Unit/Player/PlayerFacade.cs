using NaughtyAttributes;
using Source.Code.Runtime.MV.Health;
using Source.Code.Runtime.MV.Wallet;
using Source.Code.Runtime.Unit.Jumper;
using Source.Code.Runtime.Unit.Mover;
using Source.Code.Runtime.Unit.Rotator;
using Source.Code.Runtime.Config;
using Source.Code.Runtime.Services.CameraService;
using Source.Code.Runtime.Services.InputService;
using Source.Code.Runtime.Triggers;
using UnityEngine;
using VContainer;

namespace Source.Code.Runtime.Unit.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PlayerFacade : MonoBehaviour
    {
        [Foldout("Components")] [SerializeField] private Animator _animator;
        [Foldout("Components")] [SerializeField] private Rigidbody2D _rigidBody2D;
        [Foldout("Components")] [SerializeField] private Health _health;
        [Foldout("Components")] [SerializeField] private GroundTrigger _groundTrigger;

        private IInputService _inputService;
        private IJumper _jumper;
        private PhysicsMovement _physicsMovement;
        private HorizontalRotator _rotator;
        private PlayerAnimator _playerAnimator;

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

            _playerAnimator = new PlayerAnimator(_animator);
            _physicsMovement = new PhysicsMovement(_rigidBody2D, config.MovementSpeed);
            _jumper = new PhysicJumper(_rigidBody2D, config.JumpHeight, _groundTrigger);
            _rotator = new HorizontalRotator(transform);
            Wallet = new Wallet(walletView);

            _health.Initialize(config.Health);
            healthView.Initialize(_health);

            Subscribe();
            cameraService.SetTarget(transform);
        }

        private void Subscribe()
        {
            _inputService.MovementButtonPressing += _physicsMovement.Move;
            _inputService.MovementButtonPressing += _rotator.Rotate;
            _inputService.MovementButtonReleased += _physicsMovement.Stop;

            _inputService.JumpButtonPressed += _jumper.Jump;

            _physicsMovement.Moved += _playerAnimator.PlayWalk;
            _physicsMovement.Stopped += _playerAnimator.StopWalk;

            _groundTrigger.Exited += _playerAnimator.PlayJump;
            _groundTrigger.Entered += _playerAnimator.StopJump;
        }

        private void OnDestroy()
        {
            _inputService.MovementButtonPressing -= _physicsMovement.Move;
            _inputService.MovementButtonPressing -= _rotator.Rotate;
            _inputService.MovementButtonReleased -= _physicsMovement.Stop;

            _inputService.JumpButtonPressed -= _jumper.Jump;
            
            _physicsMovement.Moved -= _playerAnimator.PlayWalk;
            _physicsMovement.Stopped -= _playerAnimator.StopWalk;
            
            _groundTrigger.Exited -= _playerAnimator.PlayJump;
            _groundTrigger.Entered -= _playerAnimator.StopJump;
        }
    }
}