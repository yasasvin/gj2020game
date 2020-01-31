using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Collectable Item", menuName = "BrokenItems/Collectable", order = 1)]
public class BrokenItemObjectCollectable : BrokenItemObject
{
    public override void BreakHarder(GameObject gameObject, bool cont)
    {
        return;
    }

    public override void FixObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}