using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Moveable Item", menuName = "BrokenItems/Moveable", order = 1)]
public class BrokenItemObjectMoveable : BrokenItemObject
{
    public override void BreakHarder(GameObject gameObject, bool cont)
    {
        return;
    }

    public override void FixObject(GameObject gameObject)
    {
        if (GameController.CONTROLLER.movingItem != null)
        {
            GameController.CONTROLLER.movingItem.GetComponent<Rigidbody>().isKinematic = false;
            GameController.CONTROLLER.movingItem.GetComponent<Rigidbody>().useGravity = false;
        }
        GameController.CONTROLLER.movingItem = gameObject;
    }
}