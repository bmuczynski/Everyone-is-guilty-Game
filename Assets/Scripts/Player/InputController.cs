using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private PlayerInputActions playerInput;


    void Start()
    {
        playerInput = new PlayerInputActions();
        playerInput.Player.Enable();
        playerInput.Player.Movement.performed += ManageMouseInput;
    }

    private void ManageMouseInput(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        Ray mouseInput = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
    }
}
