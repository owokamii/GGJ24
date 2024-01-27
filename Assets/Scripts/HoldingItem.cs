using UnityEngine;

public class HoldingItem : MonoBehaviour
{
    public ItemType ItemType;
    public HealthBar healthBar;
    public bool isCurrentlyInteracting = false;
    public Sprite sprite;
    
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public CanvasGroup healthBarCanvasGroup;
    private bool HealbarWasFull;
    public HealthBar healthbar;

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

        }
        else if (isCurrentlyInteracting && healthBar.IsFull() && sprite == null)
        {
            healthBarCanvasGroup.alpha = 0;
            CalculateEnding.UpdateItemStatus(ItemType, true);
            Destroy(gameObject);
        }
        else if (isCurrentlyInteracting && !HealbarWasFull && healthBar.Click == false)
        {
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
        //if(healthBar.slider.value != 0)
        //{
        //    animator.SetBool("Interacting", false);
        //}
        isCurrentlyInteracting = false;
        healthBar.Click = false;
    }

    public void ChangeSprite()
    {
        CalculateEnding.UpdateItemStatus(ItemType, true);
        spriteRenderer.sprite = sprite;
    }
}

