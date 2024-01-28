using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject[] nextCutscene;
    public GameObject nextDialogue;
    public TMP_Text textComponent;
    public string[] lines;
    public float textSpeed;

    public Image[] cutscenes;

    private int index;

    private void Start()
    {
        nextCutscene[0].SetActive(true);
        textComponent.text = string.Empty;
        StartDialogue();
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
    }

    private void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

            Debug.Log(index);
            switch(index)
            {
                case 1:
                    Debug.Log("A");
                    nextCutscene[1].SetActive(true);
                    break;
                case 2:
                    Debug.Log("B");
                    nextCutscene[2].SetActive(true);
                    break;
            }
        }
        else
        {
            if(nextDialogue != null)
            {
                Invoke("TriggerDialogue", 3.0f);
            }
            gameObject.SetActive(false);
        }
    }

    private void TriggerDialogue()
    {
        nextDialogue.SetActive(true);
    }
}
