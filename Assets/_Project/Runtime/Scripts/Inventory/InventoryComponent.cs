using UnityEngine;
using UnityEngine.Events;

namespace _Project.Runtime.Scripts.Inventory
{
    public class InventoryComponent : MonoBehaviour
    {
        //Fields
        private int _bombAmount;
        private int _maxBombAmount = 3;
        [SerializeField] private GameObject _bombPrefab;

        //Actions
        public UnityAction<int> OnBombAmountChanged; //Take in parameter the new amount of bombs
        public UnityAction<int> OnBombsAdded; //Take in parameter the amount added
        public UnityAction<int> OnBombsRemoved; //Take in parameter the amount removed
        public UnityAction OnBombUsed;
        
        #region Properties

        private int BombAmount
        {
            get => _bombAmount;
            set
            {
                _bombAmount = Mathf.Clamp(value, 0, _maxBombAmount);
                OnBombAmountChanged?.Invoke(_bombAmount);
            }
        }

        #endregion

        public void AddBombs(int amount)
        {
            BombAmount += amount;
            OnBombsAdded?.Invoke(amount);
        }

        public void RemoveBombs(int amount)
        {
            BombAmount -= amount;
            OnBombsRemoved?.Invoke(amount);
        }

        public void UseBomb(Vector2 instantiationPosition, Quaternion instantiationRotation)
        {
            if(_bombAmount <= 0) return;
            
            RemoveBombs(1);

            Instantiate(_bombPrefab, instantiationPosition, instantiationRotation);
            
            OnBombUsed?.Invoke();
        }
    }
}
