using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    private Animator animator;
    public GameObject[] nextCutscene;
    public GameObject nextDialogue;
    public GameObject ring;
    public TMP_Text textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    private void Start()
    {
        animator = GetComponent<Animator>();

        if (index < nextCutscene.Length)
        {
            nextCutscene[0].SetActive(true);
        }
        else
        {
        }
        textComponent.text = string.Empty;
        Invoke("StartDialogue", 1);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // type each character 1 by 1
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        //animator.SetBool("DialogueBox", false);
    }

    private void NextLine()
    {
        //animator.SetBool("DialogueBox", true);

        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

            switch(index)
            {
                case 1:
                    nextCutscene[1].SetActive(true);
                    break;
                case 2:
                    nextCutscene[2].SetActive(true);
                    break;
            }
        }
        else
        {
            if(nextDialogue != null)
            {
                Invoke("TriggerRing", 1);
                Invoke("TriggerDialogue", 3.0f);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            gameObject.SetActive(false);
        }
    }

    private void TriggerDialogue()
    {
        nextDialogue.SetActive(true);
    }

    private void TriggerRing()
    {
        ring.SetActive(true);
    }
}
