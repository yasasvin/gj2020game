using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceController : MonoBehaviour
{
    bool dancechange = (Random.value > 0.5);
    Animator Anim;

    void Start()
    {
        Anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        dancechange = (Random.value > 0.5);
        Anim.SetBool("ChangeMove", dancechange);
        Debug.Log(dancechange);
    }
}
