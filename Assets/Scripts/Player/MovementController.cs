using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// controller for grid movement system
public class MovementController : MonoBehaviour
{
    private bool isMoving;
    private Vector3 targetPosition;

    // weird movement when assigning a value
    [SerializeField]
    private float timeToMove;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.forward));
        }
        if (Input.GetKeyDown(KeyCode.S) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.back));
        }
        if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }
        if (Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }
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
