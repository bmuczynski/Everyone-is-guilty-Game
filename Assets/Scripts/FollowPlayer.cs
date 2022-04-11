using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private float cameraDistance = 1.0f;

    private Transform playerTransform;
    private Vector3 offset;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTransform.position;
    }

    // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
    void LateUpdate() => transform.position = playerTransform.position + offset * cameraDistance;
    
}
