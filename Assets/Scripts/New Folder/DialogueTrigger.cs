using Dypsloom.RhythmTimeline.Core.Notes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    private Image btt;
    // Start is called before the first frame update
    public Dialogue dialogue;
    private void Start()
    {
       btt = FindObjectOfType<Image>();
       FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void TriggerDialoge()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        btt.enabled = false;
    }
    
}
