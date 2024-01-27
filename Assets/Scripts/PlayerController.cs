using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float interactionRange = 1.5f;
    public LayerMask interactableLayer;
    public LayerMask HoldingLayer;
    public LayerMask WearingMask;
    public HealthBar healthBar;
    public GameObject selectionPanel;

    private HoldingItem currentInteractingItem = null;

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            CheckForItems();
        }
        else
        {
            if (currentInteractingItem != null)
            {
                currentInteractingItem.StopInteraction();
                currentInteractingItem = null;
            }
            healthBar.Click = false;
        }
    }

    private void CheckForItems()
    {
        Collider2D closestHit = null;
        float closestDistance = float.MaxValue;

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionRange, interactableLayer | HoldingLayer | WearingMask);

        foreach (var hit in hits)
        {
            float distance = (hit.transform.position - transform.position).sqrMagnitude;
            if (distance < closestDistance)
            {
                closestHit = hit;
                closestDistance = distance;
            }
        }

        if (closestHit != null)
        {
            ProcessInteraction(closestHit);
        }
    }

    private void ProcessInteraction(Collider2D hit)
    {
        if (((1 << hit.gameObject.layer) & interactableLayer) != 0)
        {
            InteractWithHealthItem(hit.GetComponent<Item>());
        }
        else if (((1 << hit.gameObject.layer) & HoldingLayer) != 0)
        {
            var item = hit.GetComponent<HoldingItem>();
            if (item != null && currentInteractingItem != item)
            {
                if (currentInteractingItem != null)
                {
                    currentInteractingItem.StopInteraction();
                }
                currentInteractingItem = item;
                currentInteractingItem.StartInteraction();
            }
        }
        else if (((1 << hit.gameObject.layer) & WearingMask) != 0)
        {
            if (selectionPanel != null)
            {
                selectionPanel.SetActive(true);
                Time.timeScale = 0f;
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

