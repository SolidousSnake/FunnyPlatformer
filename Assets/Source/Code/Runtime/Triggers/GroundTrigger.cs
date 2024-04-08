using System;
using UnityEngine;

namespace Source.Code.Runtime.Triggers
{
    public sealed class GroundTrigger : MonoBehaviour
    {
        private int _counter;

        public event Action Entered;
        public event Action Exited;
        
        public bool Triggered => _counter > 0;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.isTrigger)
                return;
            
            _counter++;
            Entered?.Invoke();
        }
        
        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.isTrigger)
                return;
            
            _counter--;
            Exited?.Invoke();
        }
    }
}