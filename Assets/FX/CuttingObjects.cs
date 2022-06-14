using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingObjects : MonoBehaviour
{
    [SerializeField]
    private Transform targetobject;

    [SerializeField]
    private LayerMask wallMask;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }
    // Update is called once per frame
     private void Update()
    {
        Vector2 CutOutPos = mainCamera.WorldToViewportPoint(targetobject.position);
        CutOutPos.y /= (Screen.width / Screen.height);

        Vector3 Offset = targetobject.position - transform.position;
        RaycastHit[] hitObject = Physics.RaycastAll(transform.position, Offset, Offset.magnitude, wallMask);

        for(int i = 0; i < hitObject.Length; i++) 
        {
            Material[] materials = hitObject[i].transform.GetComponent<Renderer>().materials;

            for (int m = 0; m < materials.Length; ++m)
            {
                materials[m].SetVector("_CutOutPos", CutOutPos);
                materials[m].SetFloat("_CutOutSize", 0.1f);
                materials[m].SetFloat("_FallofSize", 0.05f);
                
            }
        }


    }
}
