using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType itemType;

    public Sprite sprite;
    private SpriteRenderer spriteRenderer;

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
            Debug.Log("First");
            CalculateEnding.UpdateItemStatus(itemType, true);
            spriteRenderer.sprite = sprite;
            //Destroy(gameObject);
        }
        else
        {
            CalculateEnding.UpdateItemStatus(itemType, true);
            Destroy(gameObject);
        }
    }


}