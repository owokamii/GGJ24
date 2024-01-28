using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public void InitiateDialogue()
    {
        dialogueBox.SetActive(true);
    }
}
