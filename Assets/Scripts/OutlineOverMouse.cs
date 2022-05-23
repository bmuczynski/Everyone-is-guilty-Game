using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OutlineOverMouse : MonoBehaviour
{
    public Outline outline;
    public bool isHovered;

    // Start is called before the first frame update
    void Awake()
    {
        outline = GetComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineHidden;
        SetOutlineColor();
        outline.OutlineWidth = 5.0f;

        isHovered = false;
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

    private void Update()
    {
        if (isHovered)
        {
            outline.enabled = true;
            outline.OutlineMode = Outline.Mode.OutlineAndSilhouette;
            isHovered = false;
        }
        else if(!isHovered)
        {
            outline.enabled = false;
        }
    }
}
