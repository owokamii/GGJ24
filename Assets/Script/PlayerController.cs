using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerController : MonoBehaviour
{
    public float interactionRange = 1.5f;
    public LayerMask interactableLayer;
    public LayerMask HoldingLayer;
    public HealthBar healthBar;

    private HoldingItem currentInteractingItem = null;

    private bool isInteractingWithHoldingLayer = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            CheckForItems();
        }
        else
        {
            isInteractingWithHoldingLayer = false;
            healthBar.Click = false;
            //Debug.Log("U no holding E");
        }
    }

    private void CheckForItems()
    {
        if (isInteractingWithHoldingLayer) return;
        
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionRange, interactableLayer | HoldingLayer);

        foreach (var hit in hits)
        {
            //Debug.Log("Hit: " + hit.gameObject.name + ", Layer: " + hit.gameObject.layer);
            if (((1 << hit.gameObject.layer) & interactableLayer) != 0)
            {
                InteractWithHealthItem(hit.GetComponent<Item>());
                break;
            }
            else if (((1 << hit.gameObject.layer) & HoldingLayer) != 0)
            {

                if (((1 << hit.gameObject.layer) & HoldingLayer) != 0)
                {
                    var item = hit.GetComponent<HoldingItem>();
                    if (item != null)
                    {
                        if (currentInteractingItem != null)
                        {
                            currentInteractingItem.StopInteraction();
                        }
                        currentInteractingItem = item;
                        currentInteractingItem.StartInteraction();
                        break;
                    }
                }
            }
        }
    }

    private void InteractWithHealthItem(Item item)
    {
        if (item != null)
        {
            item.Interact();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
