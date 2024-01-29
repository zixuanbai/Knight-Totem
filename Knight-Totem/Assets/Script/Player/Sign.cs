using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sign : MonoBehaviour
{
    public GameObject signSprite;
    private bool canPress;
    public Transform playerTrans;
    private IInteractable targetItem;
    private PlayerInputControl playerInput;

    private void Awake()
    {
        playerInput = new PlayerInputControl();
        playerInput.Enable();
    }

    private void OnEnable()
    {
        playerInput.Gameplay.Comform.started += OnComform;
    }

    private void Update()
    {
        signSprite.SetActive(canPress);
        signSprite.transform.localScale = playerTrans.localScale;
    }

    
    private void OnComform(InputAction.CallbackContext obj)
    {
        if (canPress)
        {
            targetItem.TriggerAction();
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Interactable"))
        {
            canPress = true;
            targetItem = other.GetComponent<IInteractable>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canPress = false;
    }
   
}
