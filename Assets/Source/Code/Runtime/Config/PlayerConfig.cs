using UnityEngine;

namespace Source.Code.Runtime.Config
{
    [CreateAssetMenu(fileName = "New player config", menuName = "Source/Config/Player")]
    public sealed class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _health;

        public float MovementSpeed => _movementSpeed;
        public float JumpHeight => _jumpHeight;
        public float Health => _health;
    }
}