using System.Collections.Generic;
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
    public SelectionQuestion question;

    private HoldingItem currentInteractingItem = null;
    private SpriteRenderer spriteRenderer;
    private Animator playerAnimator;

    public CanvasGroup healthBarCanvasGroup;
    private HashSet<GameObject> highlightedItems = new HashSet<GameObject>();

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        if (healthBarCanvasGroup != null)
            healthBarCanvasGroup.alpha = 0;
            healthBar.HealthFull += HealthBarFull;
    }

    public void Start()
    {
        question = FindObjectOfType<SelectionQuestion>();
    }

    private void Update()
    {
        HashSet<GameObject> hitsThisFrame = new HashSet<GameObject>();

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionRange, interactableLayer | HoldingLayer | WearingMask);
        foreach (Collider2D hit in hits)
        {
            GameObject hitObject = hit.gameObject;
            hitsThisFrame.Add(hitObject);

            if ((1 << hitObject.layer & interactableLayer) != 0)
            {
                Item itemScript = hit.GetComponent<Item>();
                if (itemScript != null && !highlightedItems.Contains(hitObject))
                {
                    itemScript.ItemHighlight();
                    highlightedItems.Add(hitObject);
                }
            }
        }
        HashSet<GameObject> itemsToRemove = new HashSet<GameObject>();
        foreach (var highlightedItem in highlightedItems)
        {
            if (highlightedItem == null)
            {
                itemsToRemove.Add(highlightedItem);
                continue;
            }

            if (!hitsThisFrame.Contains(highlightedItem))
            {
                Item itemScript = highlightedItem.GetComponent<Item>();
                if (itemScript != null)
                {
                    itemScript.UnHighlight();
                }
                itemsToRemove.Add(highlightedItem);
            }
        }

        foreach (var itemToRemove in itemsToRemove)
        {
            highlightedItems.Remove(itemToRemove);
        }

        if (!Epress && Input.GetKeyDown(KeyCode.E))
        {
            Epress = true;
            CheckForItems();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            gameObject.tag = "Cleaning";
            Epress = false;
            if (currentInteractingItem != null)
            {
                //gameObject.tag = "Cleaning";
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
            /*playerAnimator.SetBool("CleaningWall", false);
            playerAnimator.SetBool("CleaningKitchen", false);
            playerAnimator.SetBool("CleaningFloor", false);*/
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
            if (item != null && currentInteractingItem != item && !item.hasBeenInteractedWith)
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
            if (selectionPanel != null && question.YesOrNo == false)
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

    private void HealthBarFull()
    {
        Epress = false;
        if (currentInteractingItem != null)
        {
            currentInteractingItem.StopInteraction();
            currentInteractingItem = null;
        }
        healthBar.Click = false;
        healthBarCanvasGroup.alpha = 0;
        /*playerAnimator.SetBool("CleaningWall", false);
        playerAnimator.SetBool("CleaningKitchen", false);
        playerAnimator.SetBool("CleaningFloor", false);*/
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("detected something");
        if(collision.CompareTag("Front"))
        {
            Debug.Log("table");
            spriteRenderer.sortingLayerName = "Background";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.sortingLayerName = "Player";
    }
}