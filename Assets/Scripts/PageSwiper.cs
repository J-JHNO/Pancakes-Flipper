using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler {
	private Vector3 panelLocation;
	public float percentThreshold = 0.2f;
	public float easing = 0.5f;
    public int totalPages = 2;
    private int currentPageX = 1;
    private int currentPageY = 1;

    void Start() {
    	panelLocation = transform.position;    
    }

    public void OnDrag(PointerEventData data) {
    	float differenceX = data.pressPosition.x - data.position.x;
        float differenceY = data.pressPosition.y - data.position.y;
        float difference;

        if (differenceX > differenceY) {
            difference = differenceX;
        } else{
            difference = differenceY;
        }



        if (differenceX > 0) {
            transform.position = panelLocation - new Vector3(differenceX, 0, 0);
        } else if (differenceY > 0) {
            transform.position = panelLocation - new Vector3(0, differenceY, 0);
        }

    }

    public void OnEndDrag(PointerEventData data) {
    	float pourcentageX = (data.pressPosition.x - data.position.x) / Screen.width;
        float pourcentageY = (data.pressPosition.y - data.position.y) / Screen.height;
        totalPages = 2;

    	if (Mathf.Abs(pourcentageX) >= percentThreshold) {
    		Vector3 newLocation = panelLocation;
            //swipe à droite
    		if ((pourcentageX > 0) && (currentPageY == 1) && (currentPageX < totalPages)) {
                currentPageX++;
    			newLocation += new Vector3(-(Screen.width+50), 0, 0);

            //swipe à gauche
    		} else if ((pourcentageX < 0) && (currentPageY == 1) && ( currentPageX > 0)) {
                currentPageX--; 
    			newLocation += new Vector3(Screen.width+50, 0, 0);

    		}

    		StartCoroutine(SmoothMove(transform.position, newLocation, easing));
    		panelLocation = newLocation;

    	} else if (Mathf.Abs(pourcentageY) >= percentThreshold) {
            Vector3 newLocation = panelLocation;
            //swipe en haut
            if ((pourcentageY > 0) && (currentPageX == 1) && (currentPageY < totalPages)) {
                Console.WriteLine(totalPages);
                currentPageY++;
                newLocation += new Vector3(0, -(Screen.height+100), 0);

            // swipe en bas
            } else if ((pourcentageY < 0) && (currentPageX == 1) && (currentPageY > 0)) {
                currentPageY--;
                newLocation += new Vector3(0, Screen.height+100, 0);
            }

            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;

        }
    }

    IEnumerator SmoothMove(Vector3 startPosition, Vector3 endPosition, float secondes) {
    	float t = 0f;
    	while (t <= 1.0) {
    		t += Time.deltaTime / secondes;
    		transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.SmoothStep(0f, 1, t));
    		yield return null; 
    	}
    }

}
