using UnityEngine;

public class HoldingItem : MonoBehaviour
{
    public ItemType ItemType;
    public HealthBar healthBar;
    public bool isCurrentlyInteracting = false;
    public Sprite[] sprite;
    
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public CanvasGroup healthBarCanvasGroup;
    private bool HealbarWasFull;
    private int i;

    private void Start()
    {
        GameObject healthBarObj = GameObject.FindGameObjectWithTag("HealthBar");

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
            animator.SetBool("Interacting", true);
            healthBarCanvasGroup.alpha = 0;
            HealbarWasFull = true;
            animator.enabled = false;

        }
        else if (isCurrentlyInteracting && healthBar.IsFull() && sprite == null)
        {
            healthBarCanvasGroup.alpha = 0;
            CalculateEnding.UpdateItemStatus(ItemType, true);
            Destroy(gameObject);
        }
        else if (isCurrentlyInteracting && !HealbarWasFull && !Input.GetKey(KeyCode.E))
        {
            Debug.Log("u left your hand");
            animator.SetBool("Interacting", false);
        }
    }

    public void StartInteraction()
    {
        animator.SetBool("Interacting", true);
        isCurrentlyInteracting = true;
        healthBar.Click = true;
    }

    public void StopInteraction()
    {
        isCurrentlyInteracting = false;
        healthBar.Click = false;
    }

    public void ChangeSprite()
    {
        CalculateEnding.UpdateItemStatus(ItemType, true);
        spriteRenderer.sprite = sprite[i];
        if(sprite.Length > 1)
        {
            Invoke("ChangeSpriteAgain", 1);
        }
    }

    private void ChangeSpriteAgain()
    {
        i++;
        spriteRenderer.sprite = sprite[i]; 
    }
}

