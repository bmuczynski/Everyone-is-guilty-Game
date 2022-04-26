using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionController : MonoBehaviour
{
    public Question question;
    public TextMeshProUGUI questionText;
    public Button choiceButton;

    private List<ChoiceController> choiceControllers = new List<ChoiceController>();

    private void Initialize()
    {
        questionText.text = question.text;

        for(int i = 0; i < question.choices.Length; i++)
        {
            ChoiceController c = ChoiceController.AddChoiceButton(choiceButton, question.choices[i], i, gameObject.transform);
            choiceControllers.Add(c);
        }
        choiceButton.gameObject.SetActive(false);
    }

    private void RemoveChoices()
    {
        foreach(ChoiceController c in choiceControllers)
        {
            Destroy(c.gameObject);
        }
        choiceControllers.Clear();
    }

    public void Hide()
    {
        RemoveChoices();
        gameObject.SetActive(false);
    }

    public void Change(Question _question)
    {
        RemoveChoices();
        question = _question;
        gameObject.SetActive(true);
        Initialize();
    }
}
