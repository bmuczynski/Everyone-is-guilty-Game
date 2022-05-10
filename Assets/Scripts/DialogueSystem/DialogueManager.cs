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
    private GameObject dialoguePanel;

    private PlayerInputActions playerInputActions;

    private Line currentLine;

    private int index = 0;

    public event Action OnDialogueEnd;

    void Start()
    {
        dialoguePanel = GameObject.Find("DialogPanel");
        Debug.Log(dialoguePanel.GetInstanceID());
        characterNameText = GameObject.Find("CharacterName").GetComponent<TextMeshProUGUI>();
        dialogueContent = GameObject.Find("ContentText").GetComponent<TextMeshProUGUI>();
        questionController = GameObject.Find("ChoiceButtons").GetComponent<QuestionController>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.UI.Enable();
        playerInputActions.UI.NextLine.performed += GoToNextLine;
        StartDialogue(dialogue);

    }

    private void OnDisable()
    {
        index = 0; // zero the index variable on disabling the Dialogue UI
    }

    // handling "Space" input for going to the next line
    private void GoToNextLine(InputAction.CallbackContext context)
    {
        if (HasNextLine()) // if there is another line after current line
        {
            StopAllCoroutines();
            dialogueContent.text = currentLine.text;
            AdvanceLine();
        }
        else if (!HasNextLine() && dialogue.question != null) // if there ain't another line after current line
        {
            StopAllCoroutines();
            characterNameText.text = "";
            dialogueContent.text = "";
            dialogueContent.text = dialogue.question.text;
            questionController.Change(dialogue.question);
        }
        else if (!HasNextLine() && dialogue.question == null)
        {
            Debug.Log("Koniec dialogu");
            EndDialogue();
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

    public void StartDialogue(Dialogue dialogue)
    {
        playerInputActions.UI.Enable();
        questionController.Hide();
        index = 0;
        this.dialogue = dialogue;
        AdvanceLine();
    }

    private void EndDialogue()
    {
        index = 0;
        dialogue = null;
        //OnDialogueEnd();
        playerInputActions.UI.Disable();
        dialoguePanel.SetActive(false);
    }

    private void AdvanceLine()
    {
        currentLine = dialogue.lines[index];
        characterNameText.text = currentLine.npc.name;
        StopAllCoroutines();
        StartCoroutine(TypeWrite(currentLine.text));
        index++;
    }

    // coroutine to make TypeWrite effect
    public IEnumerator TypeWrite (string fullText)
    {
        dialogueContent.text = "";
        for (int i = 0; i < fullText.Length; i++)
        {
            dialogueContent.text += fullText[i];
            yield return new WaitForSeconds(0.05f);
        }
    }
}
