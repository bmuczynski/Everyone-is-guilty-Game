using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public event Action onDialogue;

    [SerializeField]
    private Dialogue dialogue;

    private TextMeshProUGUI characterNameText;
    private TextMeshProUGUI dialogueContent;

    private PlayerInputActions playerInputActions;

    private bool canGoToNextLine;
    private Line currentLine;

    private int index = 0;

    void Start()
    {
        SetDialogue(dialogue);
        characterNameText = GameObject.Find("CharacterName").GetComponent<TextMeshProUGUI>();
        dialogueContent = GameObject.Find("ContentText").GetComponent<TextMeshProUGUI>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.UI.Enable();
        playerInputActions.UI.NextLine.performed += GoToNextLine;
    }

    // will set dialogue to dialogue manager on on enabling the UI canvas
    private void OnEnable()
    {
        SetDialogue(dialogue);
    }

    private void OnDisable()
    {
        index = 0;
    }

    // handling "Space" input for going to the next line
    private void GoToNextLine(InputAction.CallbackContext context)
    {
        if(HasNextLine())
        {
            ClearTextbox();
            ManageDialogs();
            index++;
        }
        else
        {
            Debug.LogWarning("There's no such line in this dialogue");
        }

    }

    private bool HasNextLine()
    {
        if (dialogue.lines.Length == index)
        {
            return false;
        }
        else return true;
    }

    // dialogue is set on the interaction with NPC
    private void SetDialogue(Dialogue dialogue)
    {
        this.dialogue = dialogue;
    }

    private void ManageDialogs()
    {
        currentLine = dialogue.lines[index];
        characterNameText.text = currentLine.npc.name;
        StopAllCoroutines();
        StartCoroutine(TypeWrite(currentLine.text));
    }

    // clear content of textBoxes
    private void ClearTextbox()
    {
        characterNameText.text = "";
        dialogueContent.text = "";
    }

    // coroutine to make TypeWrite effect
    public IEnumerator TypeWrite (string fullText)
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            dialogueContent.text += fullText[i];
            yield return new WaitForSeconds(0.2f);
        }
    }
}
