using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();    
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("starting conversation with" + dialogue.name);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Displynextsentence();
    }
    public void Displynextsentence()
    {
        if(sentences.Count ==0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;  

    }
    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
        
    // Update is called once per frame

}
