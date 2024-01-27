using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{
    public GameObject[] endingElements;
    public Sprite[] endingSprites;
    public Sprite sprite;

    void Start()
    {
        UpdateCollectionDisplay();
    }

    void UpdateCollectionDisplay()
    {
        Dictionary<string, bool> endings = GameManager.instance.endings;

        for (int i = 0; i < endingElements.Length; i++)
        {
            string endingKey = "Ending" + (i + 1);
            GameObject element = endingElements[i];
            Image elementImage = element.GetComponent<Image>();

            if (endings.ContainsKey(endingKey) && endings[endingKey])
            {
                elementImage.sprite = endingSprites[i];
            }
            else
            {
                elementImage.sprite = sprite;
            }
        }
    }
}
