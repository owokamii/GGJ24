using UnityEngine;

public class Item3 : MonoBehaviour
{
    public SelectionQuestion question;

    private SpriteRenderer spritePlayer;
    public Sprite PlayerNewSprite;
    private SpriteRenderer spriteOri;
    public Sprite original;
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

    void HandleSelectionComplete(bool selection)
    {
        Debug.Log("HandleSelectionComplete called with selection: " + selection);
        if (selection)
        {
            Debug.Log("Yes");
            spritePlayer.sprite = PlayerNewSprite;
            spriteOri.sprite = original;
        }
        else
        {
            Debug.Log("No");
        }
    }
}
