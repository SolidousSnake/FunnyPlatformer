using System;

namespace Source.Code.Runtime.Unit.Enemy.Vision
{
    public interface IVision
    {
        public event Action PlayerSighted;
        public event Action PlayerFleed;
    }
}