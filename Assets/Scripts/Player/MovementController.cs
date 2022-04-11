using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// controller for grid movement system (used New Unity Input System - PlayerInput component on Player)
public class MovementController : MonoBehaviour
{
    private Animator animator;
    private float timeToMove;
    private bool isMoving;
    private Vector3 movement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnMovement(InputValue input)
    {

        movement = input.Get<Vector3>();
        if(!isMoving)
        {
            StartCoroutine(Move(movement));
        }
        //if (!isMoving) StartCoroutine(MovePlayer(movement));
    }

    private IEnumerator Move(Vector3 movement)
    {
        isMoving = true;
        animator.Play("Slow Run");
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, movement, 2.0f, 0.0f));
        transform.Translate(movement, Space.World);
        isMoving = false;
        yield return null;
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true; // ustawienie flagi na true - porusza si�
        float elapsedTime = 0.0f;
        Vector3 targetPosition = transform.position + direction;
        animator.SetBool("isMoving", true);
        animator.PlayInFixedTime("Slow Run");

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(direction, transform.position, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        animator.SetBool("isMoving", false);
        isMoving = false;
    }
}
