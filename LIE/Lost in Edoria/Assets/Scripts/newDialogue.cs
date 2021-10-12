using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class newDialogue : MonoBehaviour
{
    /*public GameObject dialogueBox;
    public static Dialogue instance;
    public TextMeshProUGUI DialogueText;
    public string[] sentences;
    private int i;
    public bool dialogueIsPlaying = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    IEnumerator Typing()
    {
        foreach (char letter in sentences[i].ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(0.04f);
        }
    }
    public void DisplayNextSentence()
    {
        if (i < sentences.Length)
        {
            dialogueIsPlaying = true;
            StopAllCoroutines();
            dialogueBox.SetActive(true);

            DialogueText.text = "";
            StartCoroutine(Typing());
            i++;
        }
        else
        {
            dialogueIsPlaying = false;
            DialogueText.text = "";
            dialogueBox.SetActive(false);
        }
    }*/



/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
public static Dialogue instance;
public TextMeshProUGUI diaText;
private Queue<string> sentences;

private void Awake()
{
    if (instance == null)
    {
        instance = this;
    }
}

public void StartDialogue(DiaClass d)
{
    d.dialogueIsPlaying = true;
    d.dialogueBox.SetActive(true);
    sentences.Clear();
    foreach (string sentence in d.sentences)
    {
        sentences.Enqueue(sentence);
    }

    DisplayNextSentence();
}

public IEnumerator Typing(string sentence)
{
    diaText.text = "";
    foreach (char letter in sentence.ToCharArray())
    {
        diaText.text += letter;
        yield return new WaitForSeconds(0.04f);
    }
}
public void DisplayNextSentence()
{
    DiaClass d = new DiaClass();
    if (sentences.Count == 0)
    {
        EndDialogue(d);
        return;
    }

    string sentence = sentences.Dequeue();
    StopAllCoroutines();
    StartCoroutine(Typing(sentence));
}

public void EndDialogue(DiaClass d)
{
    d.dialogueIsPlaying = false;
    d.dialogueBox.SetActive(false);
}


}*/

}