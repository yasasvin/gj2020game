using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Cleanable Item", menuName = "BrokenItems/Cleanable", order = 1)]
public class BrokenItemObjectCleanable : BrokenItemObject
{
    public override void BreakHarder(GameObject gameObject, bool cont)
    {
        return;
    }

    public override void FixObject(GameObject gameObject)
    {

        Renderer r = gameObject.GetComponent<Renderer>();
        Color c = gameObject.GetComponent<Renderer>().material.color;

        r.material.color = new Color(c.r, c.g, c.b, c.a-0.005f);
        

        if (r.material.color.a <= 0.001f)
        {
            Destroy(gameObject);
        }
    }
}