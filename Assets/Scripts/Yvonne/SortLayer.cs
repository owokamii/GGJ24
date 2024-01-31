using UnityEngine;

public class SortLayer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public string changedLayer;
    public string originalLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Cleaning"))
        {
            spriteRenderer.sortingLayerName = changedLayer;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Cleaning"))
        {
            spriteRenderer.sortingLayerName = changedLayer;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.sortingLayerName = originalLayer;
    }
}
