using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    public event Action<ItemObject> OnItemPicked;

    private PlayerInputActions playerInput;


    void Start()
    {
        playerInput = new PlayerInputActions();
        playerInput.Player.Enable();
        playerInput.Player.Movement.performed += ManageMouseInput;
    }

    private void ManageMouseInput(InputAction.CallbackContext context)
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject go = hitInfo.collider.gameObject;
            if (go.tag == "Item")
            {
                Debug.Log("tag");
                ItemObject ob = hitInfo.collider.gameObject.GetComponent<Item>().item;
                OnItemPicked(ob);
                DestroyImmediate(go);

            }
        }
    }
}
