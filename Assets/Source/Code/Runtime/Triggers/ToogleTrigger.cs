using NaughtyAttributes;
using UnityEngine;

namespace Source.Code.Runtime.Triggers
{
    public sealed class ToogleTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToEnable;
        [SerializeField, Layer] private int _targetLayer;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _targetLayer)
                _objectToEnable.SetActive(true);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _targetLayer)
                _objectToEnable.SetActive(false);
        }
    }
}