using UnityEngine;

namespace _Project.Runtime.Interfaces
{
    public interface IHealth
    {
        void TakeDamage(int damage);
        void Heal(int heal);
    }
}
