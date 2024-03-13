using UnityEngine;

namespace Source.Code.Runtime.Config
{
    [CreateAssetMenu(fileName = "New quote config", menuName = "Source/Config/Quotes")]
    public sealed class QuotesConfig : ScriptableObject
    {
        [SerializeField] private AudioClip[] _quotes;

        public AudioClip[] Quotes => _quotes;
    }
}