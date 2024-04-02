using NaughtyAttributes;
using Source.Code.Runtime.Config;
using Source.Code.Runtime.Core.Bootstrapper;
using Source.Code.Runtime.Core.States;
using Source.Code.Runtime.Core.States.View;
using Source.Code.Runtime.MV.Health;
using Source.Code.Runtime.MV.Timer;
using Source.Code.Runtime.MV.Wallet;
using Source.Code.Runtime.Services.CameraService;
using Source.Code.Runtime.Services.MusicService;
using Source.Code.Runtime.Unit;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Source.Code.Runtime.Core.Scope
{
    public sealed class SceneScope : LifetimeScope
    {
        [Foldout("UI")]
        [SerializeField] private WalletView _walletView;
        [Foldout("UI")]
        [SerializeField] private HealthView _healthView;
        [Foldout("UI")]
        [SerializeField] private TimerView _timerView;
        [Foldout("UI")] 
        [SerializeField] private VictoryStateView _victoryStateView;
        [Foldout("UI")]
        [SerializeField] private BaseStateView _failureStateView;
        [Foldout("UI")] 
        [SerializeField] private PauseStateView _pauseStateView;
        [Foldout("UI")]
        [SerializeField] private PlayingStateView _playingStateView;
        
        [Foldout("Camera")] 
        [SerializeField] private Vector3 _offset;
        [Foldout("Camera")]
        [SerializeField] private float _smoothing;
        
        [Foldout("Player")] 
        [SerializeField]  private PlayerConfig _playerConfig;
        [Foldout("Player")] 
        [SerializeField] private PlayerFacade _playerPrefab;
        [Foldout("Player")] 
        [SerializeField] private Vector3 _spawnPoint;

        [Foldout("SFX")] 
        [SerializeField] private AudioSource _audioSource;
        [Foldout("SFX")]
        [SerializeField] private AudioClipConfig _audioClipConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            BindConfig(builder);
            BindUI(builder);
            BindServices(builder);
            BindTimer(builder);
            BindPlayer(builder);
            BindStateMachine(builder);

            builder.RegisterEntryPoint<LevelBootstrapper>();
        }
        
        private void BindStateMachine(IContainerBuilder builder)
        {
            builder.Register<GameStateMachine>(Lifetime.Singleton);

            builder.Register<IState, PreparingState>(Lifetime.Scoped);
            builder.Register<IState, RestartState>(Lifetime.Scoped);
            builder.Register<IState, PlayingState>(Lifetime.Scoped).WithParameter(_playingStateView);
            builder.Register<IState, PauseState>(Lifetime.Scoped).WithParameter(_pauseStateView);
            builder.Register<IState, VictoryState>(Lifetime.Scoped).WithParameter(_victoryStateView);
            builder.Register<IState, FailureState>(Lifetime.Scoped).WithParameter(_failureStateView);
        }

        private void BindUI(IContainerBuilder builder)
        {
            builder.RegisterComponent(_walletView);
            builder.RegisterComponent(_healthView);
        }

        private void BindPlayer(IContainerBuilder builder)
        {
            builder.Register(container => 
                container.Instantiate(_playerPrefab, _spawnPoint, Quaternion.identity), Lifetime.Singleton);
            /*
           //NonLazy analog
           builder.RegisterBuildCallback(container =>
           {
               container.Instantiate(_playerPrefab, _spawnPoint, Quaternion.identity);
           });
           */
        }

        private void BindServices(IContainerBuilder builder)
        {
            builder.RegisterComponent(_audioSource);

            builder.Register<MusicService>(Lifetime.Singleton);
            builder.RegisterEntryPoint<CameraService>().WithParameter(_offset).WithParameter(_smoothing).AsSelf();
        }

        private void BindConfig(IContainerBuilder builder)
        {
            builder.RegisterInstance(_playerConfig);
            builder.RegisterInstance(_audioClipConfig);
        }

        private void BindTimer(IContainerBuilder builder) =>
            builder.RegisterEntryPoint<Timer>().WithParameter(_timerView).AsSelf();
    }
}