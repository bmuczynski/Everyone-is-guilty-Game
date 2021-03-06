using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Choice
{
    [TextArea(2, 5)]
    public string text;
    public Dialogue dialogue;
}

[CreateAssetMenu(fileName = "New Question", menuName = "Conversation/Question")]
public class Question : ScriptableObject
{
    [TextArea(2, 5)]
    public string text;
    public Choice[] choices;
    public AudioClip clip;
}
