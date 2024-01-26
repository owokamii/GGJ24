using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingItem : MonoBehaviour
{
    public HealthBar healthBar;
    public bool isCurrentlyInteracting = false;
    public Sprite sprite;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isCurrentlyInteracting && healthBar.IsFull() & sprite != null)
        {
           ChangeSprite();
        }
        else if (isCurrentlyInteracting && healthBar.IsFull())
        {
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
        spriteRenderer.sprite = sprite;
    }
}

