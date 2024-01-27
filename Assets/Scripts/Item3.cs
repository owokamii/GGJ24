using UnityEngine;

public class Item3 : MonoBehaviour
{
    // Start is called before the first frame update
    //public ItemType itemType;

    public SelectionQuestion question;

    private SpriteRenderer spritePlayer;
    public Sprite PlayerNewSprite;
    private SpriteRenderer spriteOri;
    public Sprite original;
    public Sprite Saving;
    // Start is called before the first frame update
    void Start()
    {
        question = FindObjectOfType<SelectionQuestion>();
        spriteOri = FindObjectOfType<SpriteRenderer>();
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
            Saving = spritePlayer.sprite;
            spritePlayer.sprite = PlayerNewSprite;
            spriteOri.sprite = original;
            original = Saving;
            //CalculateEnding.UpdateItemStatus(itemType, true);
            //Debug.Log("Yes");
        }
        else
        {
            Debug.Log("No");
            //Destroy(gameObject);
            //CalculateEnding.UpdateItemStatus(itemType, true);
            //Debug.Log("No");
        }
    }
}
