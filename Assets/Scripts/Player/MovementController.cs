using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// controller for grid movement system (used New Unity Input System - PlayerInput component on Player)
public class MovementController : MonoBehaviour
{
    private bool isMoving;
    private Vector3 targetPosition;
    private PlayerInput playerInput;

    // weird movement when assigning a value
    [SerializeField]
    private float timeToMove;

    private void Awake()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        Debug.Log(playerInput.devices);
    }

    public void OnMovement(InputValue input)
    {
        Vector3 movement = input.Get<Vector3>();
        if(!isMoving) StartCoroutine(MovePlayer(movement));
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0.0f;
        targetPosition = transform.position + direction;

        while (elapsedTime < timeToMove)
        { 
            transform.position = Vector3.Lerp(direction, transform.position, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
    }
}
