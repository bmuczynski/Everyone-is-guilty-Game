using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class TypeWriter : MonoBehaviour
{
    private readonly float typeSpeed = 0.1f;
    private TextMeshProUGUI text;
    public string fullText;
    private string currentText = "";

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        TypeWriteText("hello i'm simple text just to present this option");
    }

    // function to be event handled - on being invoked it will typewrite text on TMProText
    private void TypeWriteText(string text)
    {
        fullText = text;
        StartCoroutine(ShowText());
    }

    public IEnumerator ShowText()
    {
        for(int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            text.text = currentText;
            yield return new WaitForSeconds(typeSpeed);
        }

    }
}
