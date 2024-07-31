using _Project.Runtime.Scripts.Interaction;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Runtime.Scripts.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        //InputActions
        [Header("InputActions")]
        [SerializeField] private InputActionReference _interact;
        
        //Components
        [Header("Components")]
        [SerializeField] private InteractionComponent _interactionComp;

        private void DoInteraction(InputAction.CallbackContext ctx)
        {
            Debug.Log("PlayerInteract");
            
            if (ctx.started)
            {
                _interactionComp.DoInteraction(this);
            }
        }
        
        private void OnEnable()
        {
            _interact.action.started += DoInteraction;
        }

        private void OnDisable()
        {
            _interact.action.started -= DoInteraction;
        }
    }
}
