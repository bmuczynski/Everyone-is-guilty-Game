using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType
{
    Dialogue,
    Movement,
    Attack
}

public class InputMapManagement : MonoBehaviour
{
    PlayerInputActions inputActions;
    // Start is called before the first frame update
    void Start()
    {
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
        GameObject.Find("DialogueManager").GetComponent<DialogueManager>().OnDialogueEvent += ManageInputMap;
    }

    private void ManageInputMap(InputType inputType)
    {
        if(inputType.Equals(InputType.Dialogue))
        {
            inputActions.Player.Disable();
            inputActions.UI.Enable();
        }
        else if(inputType.Equals(InputType.Movement))
        {
            inputActions.Player.Enable();
            inputActions.UI.Disable();
        }
    }
}
