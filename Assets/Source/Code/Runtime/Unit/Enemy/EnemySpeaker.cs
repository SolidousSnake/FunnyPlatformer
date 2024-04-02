using UnityEngine;

namespace Source.Code.Runtime.Unit.Enemy
{
    public class EnemySpeaker
    {
        private readonly AudioSource _source;

        public EnemySpeaker(AudioSource source)
        {
            _source = source;
        }
        
        public void Speak(AudioClip clip)
        {
            if(!_source.isPlaying)
                _source.PlayOneShot(clip);
        }
    }
}