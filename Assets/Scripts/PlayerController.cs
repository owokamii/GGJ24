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
    private bool Epress = false;

    private HoldingItem currentInteractingItem = null;

    public CanvasGroup healthBarCanvasGroup;

    private void Awake()
    {
        if (healthBarCanvasGroup != null)
            healthBarCanvasGroup.alpha = 0;
    }

    private void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionRange, interactableLayer | HoldingLayer | WearingMask);
        foreach (Collider2D hit in hits)
        {
            //Debug.Log(hit.gameObject.name + " at distance: ");

            if ((hit.gameObject.layer & interactableLayer) != 0)
            {
                Debug.Log("hello");
                Item itemScript = hit.GetComponent<Item>();
                if (itemScript != null)
                {
                    Debug.Log("hello");
                    itemScript.ItemHighlight();
                }
            }
            else if ((hit.gameObject.layer & HoldingLayer) != 0)
            {

            }
        }

        if (!Epress && Input.GetKeyDown(KeyCode.E))
        {
            Epress = true;
            CheckForItems();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            Epress = false;
            if (currentInteractingItem != null)
            {
                currentInteractingItem.StopInteraction();
                currentInteractingItem = null;
            }
            healthBar.Click = false;
            healthBarCanvasGroup.alpha = 0;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            if (currentInteractingItem != null && healthBarCanvasGroup != null)
            {
                healthBarCanvasGroup.alpha = 1;
            }
        }
        else
        {
            if (currentInteractingItem != null)
            {
                currentInteractingItem.StopInteraction();
                currentInteractingItem = null;
            }
            healthBar.Click = false;
            if (healthBarCanvasGroup != null)
                healthBarCanvasGroup.alpha = 0;
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
            Debug.Log(hit.gameObject.name + " at distance: " + Mathf.Sqrt(distance));
            if (distance < closestDistance)
            {
                closestHit = hit;
                closestDistance = distance;
            }
        }

        if (closestHit != null)
        {
            Debug.Log("Interacting with closest item: " + closestHit.gameObject.name);
            ProcessInteraction(closestHit);
        }

        if (closestHit == null || !Input.GetKey(KeyCode.E))
        {
            if (healthBarCanvasGroup != null)
                healthBarCanvasGroup.alpha = 0;
        }
    }

    private void ProcessInteraction(Collider2D hit)
    {
        if (((1 << hit.gameObject.layer) & interactableLayer) != 0)
        {
            InteractWithHealthItem(hit.GetComponent<Item>());
            return;
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

                if (healthBarCanvasGroup != null)
                    healthBarCanvasGroup.alpha = 1;
            }
            return;
        }
        else if (((1 << hit.gameObject.layer) & WearingMask) != 0)
        {
            if (selectionPanel != null)
            {
                selectionPanel.SetActive(true);
                Time.timeScale = 0f;
            }
            return;
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

