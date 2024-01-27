using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType itemType;

    public Sprite spriteHighlight; // dirty highlight
    public Sprite originalSprite; // originalSprite
    public Sprite sprite; //clean
    private SpriteRenderer spriteRenderer; // dirty => clean
    private bool isInteracted = false;

    [Header("Maid Outfit")]
    public SpriteRenderer spritePlayer;
    public Sprite PlayerNewSprite;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        if (sprite != null)
        {
            CalculateEnding.UpdateItemStatus(itemType, true);
            spriteRenderer.sprite = sprite;
            isInteracted = true;
        }
        else
        {
            CalculateEnding.UpdateItemStatus(itemType, true);
            Destroy(gameObject);
        }
    }

    public void ItemHighlight()
    {
        if(!isInteracted)
        {
            spriteRenderer.sprite = spriteHighlight;
        }
        else
        {
            spriteHighlight = null;
        }
    }

    public void UnHighlight()
    {
        if (!isInteracted)
        {
            spriteRenderer.sprite = originalSprite;
        }
        else
        {
            originalSprite = null;
        }
    }
}