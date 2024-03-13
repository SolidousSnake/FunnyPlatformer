using System;

namespace Source.Code.Runtime.Core.Interfaces
{
    public interface IVision
    {
        public event Action PlayerSighted;
        public event Action PlayerFleed;
    }
}
