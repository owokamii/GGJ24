using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item3 : MonoBehaviour
{
    // Start is called before the first frame update
    public ItemType itemType;

    public SelectionQuestion question;

    private SpriteRenderer spritePlayer;
    public Sprite PlayerNewSprite;
    // Start is called before the first frame update
    void Start()
    {
        question = FindObjectOfType<SelectionQuestion>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            spritePlayer = playerObj.GetComponent<SpriteRenderer>();
        }

        if (question != null)
        {
            question.OnSelectionComplete += HandleSelectionComplete;
        }
    }

    // Update is called once per frame
    void HandleSelectionComplete(bool selection)
    {
        Debug.Log("HandleSelectionComplete called with selection: " + selection);
        if (selection)
        {
            Debug.Log("Yes");
            spritePlayer.sprite = PlayerNewSprite;
            Destroy(gameObject);
            CalculationSystem.UpdateItemStatus(itemType, true);
            //Debug.Log("Yes");
        }
        else
        {
            Debug.Log("No");
            Destroy(gameObject);
            CalculationSystem.UpdateItemStatus(itemType, true);
            //Debug.Log("No");
        }
    }
}
