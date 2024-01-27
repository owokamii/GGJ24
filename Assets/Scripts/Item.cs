using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType itemType;

    public Sprite sprite;
    private SpriteRenderer spriteRenderer;

    public SelectionQuestion question;

    public SpriteRenderer spritePlayer;
    public Sprite PlayerNewSprite;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        question.OnSelectionComplete += HandleSelectionComplete;
    }

    void HandleSelectionComplete(bool selection)
    {
        if (selection)
        {
            CalculationSystem.UpdateItemStatus(itemType, true);
            spritePlayer.sprite = PlayerNewSprite;
            Destroy(gameObject);
            //Debug.Log("Yes");
        }
        else
        {
            CalculationSystem.UpdateItemStatus(itemType, true);
            Destroy(gameObject);
            //Debug.Log("No");
        }
    }

    public void Interact()
    {
        if (sprite != null)
        {
            Debug.Log("First");
            CalculationSystem.UpdateItemStatus(itemType, true);
            spriteRenderer.sprite = sprite;
        }
        else
        {
            CalculationSystem.UpdateItemStatus(itemType, true);
            Destroy(gameObject);
        }
    }


}