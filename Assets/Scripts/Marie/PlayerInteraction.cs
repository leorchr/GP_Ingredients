using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerInteractionAnim _anim;
    private Inventory _inventory;
    private InteractionType _possibleInteraction = InteractionType.None;
    private KeyItem _possiblePickable;
    private Interactive _possibleInteractive;


    private void Start()
    {
        _anim = GetComponent<PlayerInteractionAnim>();
        _inventory = GetComponent<Inventory>();
    }

    public void SetInteraction(InteractionType interaction)
    {
        _possibleInteraction = interaction;
        InteractionHelper.Instance.Show(interaction);
    }

    public void Interact(InputAction.CallbackContext ctx)
    {
        if (_possibleInteraction != InteractionType.None && ctx.started)
        {
            _anim.PlayAnimation(_possibleInteraction);
            if (_possibleInteraction == InteractionType.Pickup)
            {
                Invoke("Pickup", 2f);
            }
            else
            {
                Invoke("Interact", 1f);
            }
        }
    }

    private void Pickup()
    {
        _inventory.PickupKeyItem(_possiblePickable.data);
        if(_possiblePickable.gameObject.transform.parent.gameObject.transform.parent.name == "GoodButtons")
        {
            GroundButtons.button_check -= 1;
        }
        _possiblePickable.gameObject.SetActive(false);
        SetInteraction(InteractionType.None);
    }

    private void Interact()
    {
        if (_inventory.IsItemFound(_possibleInteractive.requiredItem))
        {
            _possibleInteractive.OnInteraction();
            if (_possibleInteractive.onlyOnce)
            {
                DisableInteractive();
            }
        }
        else
        {
            _anim.PlayAnimation(_possibleInteractive.interactionType);
            Invoke("OnFail", 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!PlayerInteractionAnim.AnimationInProgress)
        {
            if (other.transform.CompareTag("Pickable"))
            {
                if (_inventory.isPickable())
                {
                    SetInteraction(InteractionType.Pickup);
                    _possiblePickable = other.GetComponentInChildren<KeyItem>();
                }
            }
            else if (other.transform.CompareTag("Interactive"))
            {
                Interactive interactive = other.GetComponent<Interactive>();
                //if interaction doesn't need key object or interaction key object is in inventory
                bool hasRequiredItem = _inventory.IsItemFound(interactive.requiredItem);
                if (!interactive.waitForObject || hasRequiredItem)
                {
                    _possibleInteractive = interactive;
                    SetInteraction(_possibleInteractive.interactionType);
                }

            }
        }
    }

    private void OnFail()
    {
        _anim.PlayAnimation(InteractionType.FailedAction);
        SetInteraction(InteractionType.FailedAction);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!PlayerInteractionAnim.AnimationInProgress)
        {
            if (other.transform.CompareTag("Pickable"))
            {
                if (_possibleInteraction == InteractionType.Pickup)
                {
                    SetInteraction(InteractionType.None);
                    _possiblePickable = null;
                }
            }
            else if (other.transform.CompareTag("Interactive"))
            {
                SetInteraction(InteractionType.None);
                _possibleInteractive = null;
            }
        }
    }
    
    private void DisableInteractive()
    {
        _possibleInteractive.GetComponent<SphereCollider>().enabled = false;
        Destroy(_possibleInteractive);
        SetInteraction(InteractionType.None);
    }
}
