using System.Collections;
using System.Collections.Generic;
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
            CalculationSystem.UpdateItemStatus(itemType, true);
            spriteRenderer.sprite = sprite;
            //Destroy(gameObject);
        }
        else
        {
            CalculationSystem.UpdateItemStatus(itemType, true);
            Destroy(gameObject);
        }
    }


}