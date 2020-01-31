using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "FIRE", menuName = "BrokenItems/Fire", order = 1)]
public class BrokenItemObjectFireFight : BrokenItemObject
{
    public override void BreakHarder(GameObject gameObject, bool cont)
    {
        if (cont)
        {
            Renderer r = gameObject.GetComponent<Renderer>();
            Color c = gameObject.GetComponent<Renderer>().material.color;
            
            r.material.color = new Color(c.r, c.g, c.b, Mathf.Min(c.a + (0.005f * (1 + gameObject.transform.childCount)), 1f));
        }
    }

    public override void FixObject(GameObject gameObject)
    {
        Renderer r = gameObject.GetComponent<Renderer>();
        Color c = gameObject.GetComponent<Renderer>().material.color;

        r.material.color = new Color(c.r, c.g, c.b, c.a - (0.01f * (1 / (1 + gameObject.transform.childCount))));
        

        if (r.material.color.a <= 0.001f)
        {
            Destroy(gameObject);
        }
    }
}