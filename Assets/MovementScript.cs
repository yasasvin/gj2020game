using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementScript : MonoBehaviour
{
    NavMeshAgent agent;

    public LayerMask clickArea;
    private NavMeshAgent MyAgent;

    void Start()
    {
        MyAgent = GetComponent<NavMeshAgent>();
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
    }
}
