using UnityEngine;

public class Item : MonoBehaviour
{
    public Animator playerAnimator;
    public GameObject player;

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
            Destroy(gameObject, 1.01f);
        }
        if(gameObject.CompareTag("Wall"))
        {
            playerAnimator.SetBool("CleaningWall", true);
            Invoke("StopCleaningWall", 1);
        }
        if (gameObject.CompareTag("Kitchen"))
        {
            playerAnimator.SetBool("CleaningKitchen", true);
            Invoke("StopCleaningKitchen", 1);
        }
        Invoke("FinishedCleaning", 1);
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

    public void StopCleaningWall()
    {
        playerAnimator.SetBool("CleaningWall", false);
    }

    public void StopCleaningKitchen()
    {
        playerAnimator.SetBool("CleaningKitchen", false);
    }

    public void FinishedCleaning()
    {
        player.tag = "Player";
    }
}