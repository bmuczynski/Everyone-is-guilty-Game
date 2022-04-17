using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;

    private void Update() => MoveMarker();

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") GameObject.Destroy(gameObject);
    }

    private void MoveMarker()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,
            1,
            transform.position.z),
            step);
    }
}
