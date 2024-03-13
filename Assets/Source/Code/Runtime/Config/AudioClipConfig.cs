using UnityEngine;

namespace Source.Code.Runtime.Config
{
    [CreateAssetMenu(fileName = "New music config", menuName = "Source/Config/Music")]
    public sealed class AudioClipConfig : ScriptableObject
    {
        [SerializeField] private AudioClip _startClip;
        [SerializeField] private AudioClip _loopClip;
        [SerializeField] private AudioClip _victoryClip;
        [SerializeField] private AudioClip _failureClip;

        public AudioClip StartClip => _startClip;
        public AudioClip LoopClip => _loopClip;
        public AudioClip VictoryClip => _victoryClip;
        public AudioClip FailureClip=> _failureClip;
    }
}