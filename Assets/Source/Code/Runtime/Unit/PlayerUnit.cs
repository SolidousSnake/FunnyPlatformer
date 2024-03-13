using NaughtyAttributes;
using Source.Code.Runtime.Core.Data;
using Source.Code.Runtime.MV.Health;
using Source.Code.Runtime.MV.Wallet;
using Source.Code.Runtime.Unit.Jumper;
using Source.Code.Runtime.Unit.Mover;
using Source.Code.Runtime.Unit.Rotator;
using Source.Code.Runtime.Config;
using Source.Code.Runtime.Services.CameraService;
using UnityEngine;
using VContainer;

namespace Source.Code.Runtime.Unit
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PlayerUnit : Unit
    {
        [Foldout("Components")] [SerializeField]
        private Animator _animator;
        [Foldout("Components")] [SerializeField] 
        private GroundCheck.GroundCheck _groundCheck;
        [Foldout("Components")] [SerializeField]
        private Rigidbody2D _rigidBody2D;
        
        private PhysicsMovement _physicsMovement;
        private PhysicJump _physicJump;
        private HorizontalRotator _rotator;

        public Wallet Wallet { get; private set; }

        private void OnValidate()
        {
            _rigidBody2D ??= GetComponent<Rigidbody2D>();
        }
        
        [Inject]
        private void Construct(WalletView walletView, HealthView healthView, PlayerConfig config, CameraService cameraService)
        {
            Initialize(config.Health);
            cameraService.SetTarget(transform);
            
            _physicsMovement = new PhysicsMovement(_rigidBody2D, config.MovementSpeed);
            _physicJump = new PhysicJump(_rigidBody2D, config.JumpHeight);
            _rotator = new HorizontalRotator(transform);
            Wallet = new Wallet();

            walletView.Initialize(Wallet);
            healthView.Initialize(Health);
        }

        private void Update()
        {
            if (Input.GetButton(Constants.Input.Horizontal))
            {
                _physicsMovement.Move(Input.GetAxisRaw(Constants.Input.Horizontal));
                _rotator.Rotate(Input.GetAxisRaw(Constants.Input.Horizontal));
            }

            if (Input.GetButtonUp(Constants.Input.Horizontal))
            {
                _physicsMovement.ResetVelocity();
            }
            
            if (Input.GetButtonDown(Constants.Input.Jump) && _groundCheck.OnGround())
            {
                _physicJump.Jump();
            }
            
            _animator.SetBool(Constants.Animation.Move, Input.GetAxis(Constants.Input.Horizontal) != 0);
            _animator.SetBool(Constants.Animation.Jump, !_groundCheck.OnGround());
        }
    }
}