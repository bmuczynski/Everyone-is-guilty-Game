using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ChoiceController : MonoBehaviour
{
    public Choice choice;
    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();  
        GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = choice.text;
    }

    public static ChoiceController AddChoiceButton(Button choiceButtonTemplate, Choice choice, int index, Transform parent)
    {
        int buttonSpacing = 45;
        Button button = Instantiate(choiceButtonTemplate);
        Debug.Log(button.GetInstanceID());
        button.transform.SetParent(parent);
        button.transform.localScale = Vector3.one;
        button.transform.localPosition = new Vector3(0, index * buttonSpacing, 0);
        button.name = "Choice " + (index + 1);
        button.gameObject.SetActive(true);

        ChoiceController choiceController = button.GetComponent<ChoiceController>();
        choiceController.choice = choice;
        return choiceController;
    }

    public void MakeChoice()
    {
        Debug.Log(gameObject.GetInstanceID());
        if(choice.dialogue != null)
        {
            dialogueManager.StartDialogue(choice.dialogue);
        }
    }
}
