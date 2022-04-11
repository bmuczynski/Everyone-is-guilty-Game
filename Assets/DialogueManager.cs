using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public event Action onDialogue;

    [SerializeField]
    private Dialogue dialogue;

    private TextMeshProUGUI characterNameText;
    private TextMeshProUGUI dialogueContent;

    void Start()
    {
        SetDialogue(dialogue);
        characterNameText = GameObject.Find("CharacterName").GetComponent<TextMeshProUGUI>();
        dialogueContent = GameObject.Find("ContentText").GetComponent<TextMeshProUGUI>();
        ManageDialogs();
    }

    // dialogue is set on the interaction with NPC
    private void SetDialogue(Dialogue dialogue)
    {
        this.dialogue = dialogue;
    }

    private void ManageDialogs()
    {
        foreach(Line line in dialogue.lines)
        {
            characterNameText.text = line.npc.name;
            StopAllCoroutines();
            StartCoroutine(TypeWrite(dialogueContent, line.text));
        }
    }

    public IEnumerator TypeWrite (TextMeshProUGUI tmpro, string fullText)
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            tmpro.text += fullText[i];
            yield return null;
        }
    }
}
