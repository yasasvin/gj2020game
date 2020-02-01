using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementScript : MonoBehaviour
{
    NavMeshAgent agent;

    public LayerMask clickArea;
    private NavMeshAgent MyAgent;
    private Transform hand;
    
    public static List<Item> CleanableItems; // Items you can clean in range. Left click to fix

    void Start()
    {
        MyAgent = GetComponent<NavMeshAgent>();
        foreach (Transform t in transform)
            if (t.name.Equals("Hand"))
            {
                hand = t;
                break;
            }

        CleanableItems = new List<Item>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;

            if (Physics.Raycast(myRay,out hitinfo,100,clickArea))
            {
                MyAgent.SetDestination(hitinfo.point);
            }
        }

        GameObject heldObject = GameController.CONTROLLER.movingItem;

        if (heldObject != null)
            ReleaseHeldItem();
        HoldItem(heldObject);
    }

    private void HoldItem(GameObject heldObject)
    {
        if (!heldObject) return;
        heldObject.transform.position = hand.transform.position;
        heldObject.transform.SetParent(hand);
        hand.GetChild(0).GetComponent<Rigidbody>().isKinematic = true;
        hand.GetChild(0).GetComponent<Rigidbody>().useGravity = false;
    }

    private void ReleaseHeldItem()
    {
        if (hand.childCount == 0) return;
        hand.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        hand.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
        hand.GetChild(0).SetParent(null);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactables"))
            CleanableItems.Add(other.GetComponent<Item>());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Book Slot"))
        {
            GameObject go = GameController.CONTROLLER.movingItem;
            if (go != null && go.GetComponent<Item>().type != null)
            {
                if (go.GetComponent<Item>().type.name.Contains("BOOK"))
                {
                    Debug.Log(other.gameObject.name);
                    hand.GetChild(0).SetParent(null);
                    FindBookSlot(other.gameObject);
                    GameController.CONTROLLER.movingItem = null;
                }
            }
        }
    }

    private void FindBookSlot(GameObject gameObject)
    {
        Transform slots = null;
        foreach (Transform t in gameObject.transform)
        {
            Debug.Log(t.name);
            if (t.name.Equals("SLOTS"))
            {
                slots = t;
            }
        }
        if (slots != null)
        {
            foreach (Transform t in slots)
            {
                if (t.gameObject.activeInHierarchy)
                {
                    GameController.CONTROLLER.movingItem.transform.position = t.position;
                    GameController.CONTROLLER.movingItem.transform.rotation = t.rotation;
                    t.gameObject.SetActive(false);
                    GameController.CONTROLLER.movingItem.GetComponent<Item>().type = null;
                    break;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactables"))
            CleanableItems.Remove(other.GetComponent<Item>());
    }
}
