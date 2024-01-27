using UnityEngine;

public class HoldingItem : MonoBehaviour
{
    public ItemType ItemType;
    public HealthBar healthBar;
    public bool isCurrentlyInteracting = false;
    public Sprite sprite;
    private SpriteRenderer spriteRenderer;
    public CanvasGroup healthBarCanvasGroup;

    private void Start()
    {
        GameObject healthBarObj = GameObject.FindGameObjectWithTag("HealthBar");
        if (healthBarObj != null)
        {
            healthBarCanvasGroup = healthBarObj.GetComponent<CanvasGroup>();
        }
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isCurrentlyInteracting && healthBar.IsFull() & sprite != null)
        {
           ChangeSprite();
            healthBarCanvasGroup.alpha = 0;
        }
        else if (isCurrentlyInteracting && healthBar.IsFull())
        {
            healthBarCanvasGroup.alpha = 0;
            CalculateEnding.UpdateItemStatus(ItemType, true);
            Destroy(gameObject);
        }
    }

    public void StartInteraction()
    {
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
        spriteRenderer.sprite = sprite;
    }
}

