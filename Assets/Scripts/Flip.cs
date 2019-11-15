using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Flip : MonoBehaviour {
    private Score score;

    private int CompareYPos(GameObject a, GameObject b)
    {
        return Math.Sign(a.transform.position.y - b.transform.position.y);
    }

    public void changeLabelText() {
        score.flips = score.flips + 1;
    }
    


    void Start()
    {
        score = (Score)GameObject.FindGameObjectWithTag("Tower").GetComponent("Score");
    }

    /*void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -1 * (Camera.main.transform.position.z));
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }*/

    void OnMouseDown()
    {
        GameObject[] pancakes = GameObject.FindGameObjectsWithTag("Pancake");
        Array.Sort(pancakes, CompareYPos);
        /*pancakes[0].GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        pancakes[1].GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        pancakes[2].GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        pancakes[3].GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        pancakes[4].GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);*/

        if (!(pancakes[pancakes.Length - 1] == gameObject))
        {
            changeLabelText();
            

            int indicePan = 0;
            foreach (GameObject pancake in pancakes)
            {
                if (pancake == gameObject)
                {
                    break;
                }
                indicePan++;
            }

            GameObject[] pancakesTmp = new GameObject[pancakes.Length - indicePan];
            int j = 0;
            for (int i=pancakes.Length-1; i >= indicePan; i--)
            {
                pancakesTmp[j] = pancakes[i];
                j++;
            }

            Vector3[] positions = new Vector3[pancakesTmp.Length];

            int k = 0;
            foreach (GameObject pancake in pancakesTmp)
            {
                positions[k] = pancake.transform.position;
                k++;
            }

            Array.Reverse(pancakesTmp);

            int l = 0;
            foreach (GameObject pancake in pancakesTmp)
            {
                pancake.transform.position = positions[l];
                l++;
            }
        }

        Array.Sort(pancakes, CompareYPos);
        /*pancakes[0].GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        pancakes[1].GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        pancakes[2].GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        pancakes[3].GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        pancakes[4].GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);*/

        
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


        GameObject victoryMessage = GameObject.FindGameObjectsWithTag("VictoryMessage")[0];
        ((VictoryMessage)victoryMessage.GetComponent("VictoryMessage")).setGagner(gagnerCalcul);
        
        

    }

    void Update()
    {
        


        /*
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position = new Vector3(-pos.x, pos.y, 0.0f);

                // Position the cube.
                transform.position = position;
            }

            if (Input.touchCount == 2)
            {
                touch = Input.GetTouch(1);

                if (touch.phase == TouchPhase.Began)
                {
                    // Halve the size of the cube.
                    transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    // Restore the regular size of the cube.
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                }
            }
        }
        */
    }
}
