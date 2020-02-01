using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    public BrokenItemObject type = null;
    public GameObject ObjectToApper;
    Renderer rendererer;
    Material material;
    Color colour;
    Rigidbody rigidbody;
    bool breakSelf = false;
    float held_time = 0;
    bool clean = false;

    public void Switcheroo()
    {
        ObjectToApper.SetActive(true);
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
        rigidbody.useGravity = false;
        rendererer = GetComponent<Renderer>();
        material = rendererer.material;
        colour = material.color;
        gameObject.layer = LayerMask.NameToLayer("Interactables");
    }

    private void Start()
    {
        if (type != null)
        {
            GetComponent<Renderer>().material.color = type.colour;
            breakSelf = true;
            ObjectToApper.SetActive(false);

            if (type.puzzle == PuzzleTypes.Moving)
            {
                rigidbody.useGravity = true;
                rigidbody.isKinematic = false;
            }
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
        if (type != null && Input.GetMouseButton(0) && MovementScript.CleanableItems.Contains(this))
        {
            breakSelf = false;
            type.FixObject(gameObject);
        }
        else
            breakSelf = true;

        
    }

    void OnMouseDown()
    {
        breakSelf = true;
        held_time += Time.deltaTime;
    }

    void OnMouseUp()
    {
        held_time = 0.0f;
    }
    void OnMouseExit()
    {



    }
}
