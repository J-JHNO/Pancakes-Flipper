using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseAnim : MonoBehaviour {
    public bool isOnPurchase = false;
    private bool direction = true;

	// Use this for initialization
	void Start () {
        isOnPurchase = false;

        direction = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        if (!isOnPurchase)
        {
            Animator animation = GameObject.FindGameObjectWithTag("Purchase").GetComponent<Animator>();
            animation.SetTrigger("InPurchase");
            animation.ResetTrigger("Come back");
            isOnPurchase = !isOnPurchase;
        }
    }

    public void Reverse()
    {
        Animator animation = GameObject.FindGameObjectWithTag("Purchase").GetComponent<Animator>();
        if (direction)
        {
            animation.SetFloat("Direction", 1.0f);
            direction = false;
        }
        else
        {
            animation.SetFloat("Direction", -1.0f);
            direction = true;
        }
        

        //Test();
    }

    public void Test()
    {
        Animator animation = GameObject.FindGameObjectWithTag("Purchase").GetComponent<Animator>();
        animation.SetTrigger("Come back");
        animation.ResetTrigger("InPurchase");
        isOnPurchase = !isOnPurchase;
    }
}
