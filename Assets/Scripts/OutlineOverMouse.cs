using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OutlineOverMouse : MonoBehaviour
{
    private Outline outline;

    // Start is called before the first frame update
    void Awake()
    {
        outline = GetComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineAndSilhouette;
        SetOutlineColor();
        outline.OutlineWidth = 5.0f;
    }

    void SetOutlineColor()
    {
        switch(gameObject.tag)
        {
            case "Enemy":
                outline.OutlineColor = Color.red;
                break;
            case "Item":
                outline.OutlineColor = Color.green;
                break;
            case "NPC":
                outline.OutlineColor = Color.yellow;
                break;
            default:
                outline.OutlineColor = Color.white;
                break;
        }
    }

    private void OnMouseOver()
    {
        Debug.Log("Mouse is over object");
        outline.OutlineMode = Outline.Mode.OutlineVisible;
    }
}
