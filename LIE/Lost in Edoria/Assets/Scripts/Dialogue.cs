using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public static Dialogue instance;
    public TextMeshProUGUI diaText;
    private Queue<string> sentences;
    public bool dialogueIsPlaying = false;
    public GameObject dialogueBox;
    public bool Toby;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(DiaClass d)
    {
        Toby = true;
        dialogueIsPlaying = true;
        dialogueBox.SetActive(true);
        sentences.Clear();
        foreach (string sentence in d.sentences)
        {
            //Enqueue adds an element to the end of the Queue
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
            yield return new WaitForSeconds(0.03f);
        }
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //Peek returns the oldest element that is at the start of the Queue
        string sentence = sentences.Peek();

        //Dequeue removes the oldest element from the start of the Queue
        sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(Typing(sentence));
    }

    public void EndDialogue()
    {
        dialogueIsPlaying = false;
        dialogueBox.SetActive(false);
        Toby = false;
    }


}
