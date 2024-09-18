using _Project.Runtime.Scripts.Controllers;
using UnityEngine;

namespace _Project.Runtime.Scripts.Items.Bomb
{
    public class BombPickUp : ItemPickUp
    {
        [SerializeField] private int _amountOfBombs;
        
        protected override void PickUp(PlayerController player)
        {
            player.InventoryComp.AddBombs(_amountOfBombs);
            
            base.PickUp(player);
        }
    }
}
