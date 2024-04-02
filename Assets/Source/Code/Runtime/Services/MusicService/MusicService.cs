using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Source.Code.Runtime.Services.MusicService
{
    public sealed class MusicService : IDisposable
    {
        private readonly AudioSource _source;
        private readonly Queue<AudioClip> _clipQueue;
        private readonly CancellationTokenSource _cts;

        public MusicService(AudioSource source)
        {
            _source = source;
            _clipQueue = new Queue<AudioClip>();
            _cts = new CancellationTokenSource();

            Reset();
        }

        public void EnqueueClip(AudioClip clip)
        {
            _clipQueue.Enqueue(clip);
        }
        
        public async UniTaskVoid PlayQueue()
        { 
            while (_clipQueue.Count > 0)
            {
                _source.clip = _clipQueue.Dequeue();
                _source.Play();

                await UniTask.WaitWhile(() => _source.isPlaying).AttachExternalCancellation(_cts.Token);
            }
            _source.loop = true;
            _source.Play();
        }

        public void PlaySpecificClip(AudioClip clip, bool loop)
        {
            _source.Stop();
            _source.loop = loop;
            _source.clip = clip;
            _source.Play();
        }

        public void Stop()
        {
            _source.Stop();
        }

        public void Pause()
        {
            _source.Pause();
        }

        public void UnPause()
        {
            _source.UnPause();
        }

        public void Dispose()
        {
            _cts.Cancel();
            Stop();
            Reset();
        }

        private void Reset()
        {
            _source.clip = null;
            _source.loop = false;
        }
    }
}
