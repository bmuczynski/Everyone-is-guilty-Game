using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Line
{
    public GameObject npc;
    [TextArea(2,5)]
    public string text;
}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation/Dialogue")]
public class Dialogue : ScriptableObject
{
    public Line[] lines;
    public Question question;
}
