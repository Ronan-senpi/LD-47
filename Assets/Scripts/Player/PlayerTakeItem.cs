using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTakeItem : MonoBehaviour
{
    private string takeButton = "Take";
    [SerializeField]
    private LayerMask takableMask;
    [SerializeField]
    private PlayerDeplacement playerDeplacement;

    private Transform item;
    private void OnTriggerStay2D(Collider2D collision)
    {
        TakeItem(collision);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeItem(collision);
    }
    protected void TakeItem(Collider2D collision)
    {
        if (Input.GetButtonDown(takeButton) && (takableMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            collision.transform.parent = this.gameObject.transform;
            item = collision.transform;
        }
    }

    private void Update()
    {
        if (item != null && Input.GetButtonUp(takeButton) && playerDeplacement.IsGrounded) 
        {
            item.parent = null;
        }
    }
}
