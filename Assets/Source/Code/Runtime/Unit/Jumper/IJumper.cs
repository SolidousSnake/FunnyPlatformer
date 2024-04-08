using System;

namespace Source.Code.Runtime.Unit.Jumper
{
    public interface IJumper
    {
        public void Jump();
        public event Action Jumped;
    }
}