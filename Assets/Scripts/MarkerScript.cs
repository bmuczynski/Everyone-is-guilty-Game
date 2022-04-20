using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;

    [SerializeField]
    private float timeForDestroy = 0.5f;

    private void Awake()
    {
        StartCoroutine(DestroyAfterTime());
    }

    private void Update() => MoveMarker();

    // niszczenie objektu przy kontakcie z playerem - niszczenie znacznika (jedna z dwóch opcji)
    private void OnTriggerEnter(Collider other)
    {
        //if(other.tag == "Player") GameObject.Destroy(gameObject);
    }

    private void MoveMarker()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,
            1,
            transform.position.z),
            step);
    }

    // coroutine to destroy object after some amount of time - musimy wybraæ co wolimy (propozycja Maæka)
    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(timeForDestroy);
        Destroy(gameObject);
    }
}
