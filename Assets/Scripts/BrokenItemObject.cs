using UnityEngine;
using System.Collections;

public abstract class BrokenItemObject : ScriptableObject
{
    public string itemName;
    public Color colour;
    public PuzzleTypes puzzle;

    public abstract void FixObject(GameObject gameObject);
    public abstract void BreakHarder(GameObject gameObject, bool cont);
}