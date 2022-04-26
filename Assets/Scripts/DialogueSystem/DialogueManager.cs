using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private Dialogue dialogue;
    private QuestionController questionController;

    private TextMeshProUGUI characterNameText;
    private TextMeshProUGUI dialogueContent;

    private PlayerInputActions playerInputActions;

    private bool canGoToNextLine;
    private bool questionAnswered;
    private Line currentLine;

    private int index = 0;

    void Start()
    {
        SetDialogue(dialogue);
        characterNameText = GameObject.Find("CharacterName").GetComponent<TextMeshProUGUI>();
        dialogueContent = GameObject.Find("ContentText").GetComponent<TextMeshProUGUI>();
        questionController = GameObject.Find("ChoiceButtons").GetComponent<QuestionController>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.UI.Enable();
        playerInputActions.UI.NextLine.performed += GoToNextLine;

    }

    // will set dialogue to dialogue manager on on enabling the UI canvas
    private void OnEnable()
    {
        SetDialogue(dialogue);
        ManageDialogs();
        questionAnswered = false;
    }

    private void OnDisable()
    {
        index = 0; // zero the index variable on disabling the Dialogue UI
    }

    // handling "Space" input for going to the next line
    private void GoToNextLine(InputAction.CallbackContext context)
    {
        if(HasNextLine()) // if there is another line after current line
        {
            questionAnswered = false;
            StopAllCoroutines();
            dialogueContent.text = currentLine.text;
            ManageDialogs();
        }
        else if(!HasNextLine() && dialogue.question != null && questionAnswered != true) // if there ain't another line after current line
        {
            StopAllCoroutines();
            characterNameText.text = "";
            ClearTextbox();
            dialogueContent.text = dialogue.question.text;
            questionController.Change(dialogue.question);
            questionAnswered = true;
        }
        else Debug.LogWarning("There's no such line in this dialogue");
    }

    private void ShowQuestion()
    {
        dialogueContent.text = dialogue.question.text;
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
    public void SetDialogue(Dialogue dialogue)
    {
        this.dialogue = dialogue;
    }

    private void ManageDialogs()
    {
        currentLine = dialogue.lines[index];
        characterNameText.text = currentLine.npc.name;
        StopAllCoroutines();
        StartCoroutine(TypeWrite(currentLine.text));
        index++;
    }

    // clear content of textBoxes
    private void ClearTextbox()
    {
        dialogueContent.text = "";
    }

    // coroutine to make TypeWrite effect
    public IEnumerator TypeWrite (string fullText)
    {
        ClearTextbox();
        for (int i = 0; i < fullText.Length; i++)
        {
            dialogueContent.text += fullText[i];
            yield return new WaitForSeconds(0.2f);
        }
    }
}
