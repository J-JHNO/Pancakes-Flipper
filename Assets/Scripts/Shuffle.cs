using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using myShuffleNamespace;

public class Shuffle : MonoBehaviour {

    private int CompareYPos(GameObject a, GameObject b)
    {
        return Math.Sign(a.transform.position.y - b.transform.position.y);
    }

    bool gagner()
    {
        GameObject[] pancakes = GameObject.FindGameObjectsWithTag("Pancake");
        Array.Sort(pancakes, CompareYPos);

        bool gagnerCalcul = true;
        for (int m = 0; m < pancakes.Length - 1; m++)
        {
            float xPancake1 = pancakes[m].GetComponent<BoxCollider2D>().size.x;
            float xPancake2 = pancakes[m + 1].GetComponent<BoxCollider2D>().size.x;
            if (xPancake1 < xPancake2)
            {
                gagnerCalcul = false;
            }
        }

        return gagnerCalcul;
    }

	// Use this for initialization
	void Start () {
        GameObject[] pancakes = GameObject.FindGameObjectsWithTag("Pancake");
        Array.Sort(pancakes, CompareYPos);

        Vector3[] positions = new Vector3[pancakes.Length];

        int i = 0;
        foreach (GameObject pancake in pancakes)
        {
            positions[i] = pancake.transform.position;
            i++;
        }

        do
        {
            ShuffleList.ShuffleL(pancakes);

            int j = 0;
            foreach (GameObject pancake in pancakes)
            {
                pancake.transform.position = positions[j];
                j++;
            }
        } while (gagner());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
