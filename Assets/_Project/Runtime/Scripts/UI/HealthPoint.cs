using UnityEngine;
using UnityEngine.UI;

namespace _Project.Runtime.Scripts.UI
{
    public class HealthPoint : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        [SerializeField] private Sprite _empty;
        [SerializeField] private Sprite _full;

        public void UpdateSprite(bool full)
        {
            _image.sprite = full ? _full : _empty;
        }
    }
}
