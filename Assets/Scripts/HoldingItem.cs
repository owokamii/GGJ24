using UnityEngine;

public class HoldingItem : MonoBehaviour
{
    public Animator playerAnimator;
    public ItemType ItemType;
    public HealthBar healthBar;
    public bool isCurrentlyInteracting = false;
    public Sprite[] sprite;
    
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public CanvasGroup healthBarCanvasGroup;
    public bool hasBeenInteractedWith = false;
    private bool HealbarWasFull;
    private int i;

    private void Start()
    {
        GameObject healthBarObj = GameObject.FindGameObjectWithTag("HealthBar");
        hasBeenInteractedWith = false;
        if (healthBarObj != null)
        {
            healthBarCanvasGroup = healthBarObj.GetComponent<CanvasGroup>();
        }
        HealbarWasFull = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isCurrentlyInteracting && healthBar.IsFull() & sprite != null && !HealbarWasFull)
        {
            ChangeSprite();
            if (animator != null)
            {
                animator.SetBool("Interacting", true);
                animator.enabled = false;
            }
            
            healthBarCanvasGroup.alpha = 0;
            HealbarWasFull = true;
            hasBeenInteractedWith = true;
            CalculateEnding.UpdateItemStatus(ItemType, true);

        }
        else if (isCurrentlyInteracting && healthBar.IsFull() && sprite == null)
        {
            Debug.Log("helloworld");
            healthBarCanvasGroup.alpha = 0;
            CalculateEnding.UpdateItemStatus(ItemType, true);
            Destroy(gameObject);
        }
        else if (isCurrentlyInteracting && !HealbarWasFull && !Input.GetKey(KeyCode.E))
        {
            Debug.Log("u left your hand");
            if (animator != null)
            {
                animator.SetBool("Interacting", false);
            }
        }
    }

    public void StartInteraction()
    {
        if (animator != null)
        {
            animator.SetBool("Interacting", true);
        }
        isCurrentlyInteracting = true;
        healthBar.Click = true;
        if(gameObject.CompareTag("Kitchen"))
        {
            playerAnimator.SetBool("CleaningKitchen", true);
        }
        else if(gameObject.CompareTag("Floor"))
        {
            playerAnimator.SetBool("CleaningFloor", true);
        }
    }

    public void StopInteraction()
    {
        isCurrentlyInteracting = false;
        healthBar.Click = false;
        playerAnimator.SetBool("CleaningKitchen", false);
        playerAnimator.SetBool("CleaningFloor", false);
    }

    public void ChangeSprite()
    {
        //CalculateEnding.UpdateItemStatus(ItemType, true);
        spriteRenderer.sprite = sprite[i];
        if(sprite.Length > 1)
        {
            Invoke("ChangeSpriteAgain", 1);
        }
    }

    public void ResetInteraction()
    {
        hasBeenInteractedWith = false;
    }

    private void ChangeSpriteAgain()
    {
        i++;
        spriteRenderer.sprite = sprite[i]; 
    }
}

