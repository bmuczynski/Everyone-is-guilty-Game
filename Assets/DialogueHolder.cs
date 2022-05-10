using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    [SerializeField]
    private Dialogue[] dialogues;

    private int currentDialogueIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentDialogueIndex = 0;
    }

    public Dialogue GetCurrDialogue()
    {
        Dialogue dialogue = dialogues[currentDialogueIndex];
        currentDialogueIndex++;
        return dialogue;
    }
}
