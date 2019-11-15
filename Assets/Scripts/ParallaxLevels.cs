using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxLevels : MonoBehaviour {
    public ScrollRect[] backgrounds;
    private ScrollRect myScrollRec;

	// Use this for initialization
	void Start () {
        myScrollRec = this.GetComponent<ScrollRect>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveOtherScroll()
    {
        Vector2 currentPos = myScrollRec.content.anchoredPosition;
        foreach (var scroll in backgrounds)
        {
            scroll.content.anchoredPosition = new Vector2(0, (scroll.scrollSensitivity * currentPos.y));
        }
    }
}
