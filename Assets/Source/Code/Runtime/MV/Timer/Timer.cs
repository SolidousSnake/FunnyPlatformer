using System.Threading;
using Cysharp.Threading.Tasks;
using Source.Code.Runtime.Core.Utils;
using UnityEngine;
using VContainer.Unity;

namespace Source.Code.Runtime.MV.Timer
{
    public sealed class Timer : IInitializable
    {
        private readonly TimerView _timerView;
        private readonly CancellationTokenSource _cancellationTokenSource;
        
        private float _elapsedTime;

        private int _seconds;
        private int _minutes;

        public Timer(TimerView timerView)
        {
            _timerView = timerView;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async void Initialize()
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                _elapsedTime += Time.fixedDeltaTime;
                _minutes = Mathf.FloorToInt(_elapsedTime / Constants.Time.SecondsInMinute);
                _seconds = Mathf.FloorToInt(_elapsedTime % Constants.Time.SecondsInMinute);
                _timerView.SetValue(_minutes, _seconds);
                await UniTask.WaitForSeconds(Time.fixedDeltaTime);
            }
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}