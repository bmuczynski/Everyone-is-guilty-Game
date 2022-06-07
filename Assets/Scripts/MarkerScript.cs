using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;

    [SerializeField]
    private float timeForDestroy = 0.5f;

    private Camera camera;

    private void Awake()
    {
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        StartCoroutine(DestroyAfterTime());
    }

    private void Update()
    {
        //transform.LookAt(camera.transform, Vector3.up);
    }

    // coroutine to destroy object after some amount of time - musimy wybraæ co wolimy (propozycja Maæka)
    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(timeForDestroy);
        Destroy(gameObject);
    }
}
