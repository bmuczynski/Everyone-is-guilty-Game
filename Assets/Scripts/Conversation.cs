using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Line
{
    public GameObject character;
    [TextArea(2, 5)]
    public string text;
}


[CreateAssetMenu(fileName = "NewConversation", menuName = "Conversation")]
public class Conversation : ScriptableObject
{
    public GameObject speakerLeft;
    public GameObject speakerRight;
    public Line[] lines;
}
