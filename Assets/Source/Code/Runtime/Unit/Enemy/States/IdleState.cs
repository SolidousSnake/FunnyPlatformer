using System.Threading;
using Cysharp.Threading.Tasks;
using Source.Code.Runtime.Config;
using Source.Code.Runtime.Core.States;
using UnityEngine;

namespace Source.Code.Runtime.Unit.Enemy.States
{
    public sealed class IdleState : IState
    {
        private readonly EnemySpeaker _speaker;
        private readonly QuotesConfig _idleQuotes;

        private readonly float _speechDelay;
        
        private readonly CancellationTokenSource _cts;

        public IdleState(EnemySpeaker speaker, QuotesConfig idleQuotes, float speechDelay)
        {
            _speaker = speaker;
            _idleQuotes = idleQuotes;
            _speechDelay = speechDelay;
            _cts = new CancellationTokenSource();
        }
        
        public void Enter()
        {
            Talk().Forget();
        }

        public void Exit()
        {
            _cts.Cancel();
        }

        private async UniTaskVoid Talk()
        {
            while (!_cts.IsCancellationRequested)
            {
                await UniTask.WaitForSeconds(_speechDelay);
                _speaker.Speak(GetRandomQuote(_idleQuotes));
            }
        }
        
        private AudioClip GetRandomQuote(QuotesConfig config)
        {
            return config.Quotes[Random.Range(0, config.Quotes.Length)];
        }
    }
}