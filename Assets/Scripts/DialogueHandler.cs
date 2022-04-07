using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueHandler : MonoBehaviour
{
    public TextMeshProUGUI speakerName;
    public TextMeshProUGUI contentText;
    private GameObject speaker;

    public GameObject Speaker
    {
        get { return speaker; }
        set { 
            speaker = value;
            speakerName.text = speaker.name.ToString();
        }
    }

    public string Dialog
    {
        set { contentText.text = value; }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void HideDialogUI()
    {
        gameObject.SetActive(false);
    }
}
