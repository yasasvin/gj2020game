using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static List<Item> MoveableItems;
    public static GameController CONTROLLER;
    public GameObject movingItem;

    private void Awake()
    {
        // enforce only 1 GameController - if it already exists, don't allow another to exist.
        if (CONTROLLER == null)
        {
            CONTROLLER = this;
            MoveableItems = new List<Item>();
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
