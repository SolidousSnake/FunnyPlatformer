using Cysharp.Threading.Tasks;

namespace Source.Code.Runtime.Weapon
{
    public interface IWeapon
    {
        public UniTask Use();
    }
}