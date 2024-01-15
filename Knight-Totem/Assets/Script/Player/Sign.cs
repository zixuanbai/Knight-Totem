using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject signSprite;
    private bool canPress;
    public Transform playerTrans;

    private void Update()
    {
        signSprite.SetActive(canPress);
        signSprite.transform.localScale = playerTrans.localScale;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Interactable"))
        {
            canPress = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canPress = false;
    }
}
