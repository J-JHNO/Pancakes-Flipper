using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMessage : MonoBehaviour {
    private Animator anim;                          // Reference to the animator component.
    private bool gagner = false;

    public void setGagner(bool g)
    {
        gagner = g;
    }

    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (gagner)
        {
            // ... tell the animator the game is over.
            anim.SetTrigger("Congrats");
        }
        
    }
}
