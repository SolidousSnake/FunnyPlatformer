using Source.Code.Runtime.Config;
using Source.Code.Runtime.Core.Interfaces;
using Source.Code.Runtime.Services.MusicService;
using VContainer;

namespace Source.Code.Runtime.Core.States
{
    public sealed class PrepearingState : IState
    {
        private readonly MusicService _musicService;
        private readonly AudioClipConfig _clipConfig;
        private readonly IObjectResolver _resolver;
        
        public PrepearingState(IObjectResolver resolver, MusicService musicService, AudioClipConfig config)
        {
            _resolver = resolver;
            _musicService = musicService;
            _clipConfig = config;
        }
        
        public void Enter()
        {
            var stateMachine = _resolver.Resolve<GameStateMachine>();
            _musicService.EnqueueClip(_clipConfig.StartClip);
            _musicService.EnqueueClip(_clipConfig.LoopClip);
            _musicService.PlayQueue().Forget();
            stateMachine.SetState<PlayingState>();
        }

        public void Exit()
        {
            
        }
    }
}