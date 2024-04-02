using Source.Code.Runtime.Config;
using Source.Code.Runtime.Core.States;
using Source.Code.Runtime.Weapon;
using UnityEngine;

namespace Source.Code.Runtime.Unit.Enemy.States
{
    public sealed class AttackState : IUpdateableState
    {
        private readonly EnemySpeaker _speaker;
        private readonly QuotesConfig _playerSightedQuotes;
        private readonly QuotesConfig _playerFleedQuotes;
        private readonly IWeapon _weapon;

        public AttackState(EnemySpeaker speaker, QuotesConfig playerSightedQuotes, QuotesConfig playerFleedQuotes
        , IWeapon weapon)
        {
            _speaker = speaker;
            _playerSightedQuotes = playerSightedQuotes;
            _playerFleedQuotes = playerFleedQuotes;
            _weapon = weapon;
        }
        
        public void Enter()
        {
            _speaker.Speak(GetRandomQuote(_playerSightedQuotes));
        }

        public void Update()
        {
            _weapon.Use();
        }
        
        public void Exit()
        {
            _speaker.Speak(GetRandomQuote(_playerFleedQuotes));
        }
        
        private AudioClip GetRandomQuote(QuotesConfig config)
        {
            return config.Quotes[Random.Range(0, config.Quotes.Length)];
        }
    }
}