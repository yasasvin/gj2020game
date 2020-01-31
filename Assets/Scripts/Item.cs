using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public BrokenItemObject type = null;
    Renderer rendererer;
    Material material;
    Color colour;
    bool breakSelf = false;

    private void Start()
    {
        rendererer = GetComponent<Renderer>();
        material = rendererer.material;
        colour = material.color;

        if (type != null)
        {
            GetComponent<Renderer>().material.color = type.colour;
            breakSelf = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (type != null)
            type.BreakHarder(gameObject, breakSelf);
    }

    void OnMouseOver()
    {
        if (type != null && Input.GetMouseButton(0))
        {
            breakSelf = false;
            type.FixObject(gameObject);
        }
        else
            breakSelf = true;
    }

    void OnMouseExit()
    {
        breakSelf = true;
    }
}
