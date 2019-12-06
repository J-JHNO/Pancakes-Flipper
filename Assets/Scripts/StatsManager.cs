using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour {
    private SQLiteHelper helper;

    // Use this for initialization
    void Start () {
        helper = new SQLiteHelper();
        //helper.createPlayerTable();
        helper.seePlayerTable();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        int flips = 0; // BD
        RefreshFlips(flips);
    }

    void RefreshFlips(int flips)
    {
        Image Flips = gameObject.transform.Find("Flips").Find("RadialFill").Find("Fill image").GetComponent<Image>();
        if (flips >= 1000000)
        {
            Flips.fillAmount = 1.0f;
        }
        else if (flips >= 100000)
        {
            Flips.fillAmount = 0.8f;
        }
        else if (flips >= 10000)
        {
            Flips.fillAmount = 0.6f;
        }
        else if (flips >= 1000)
        {
            Flips.fillAmount = 0.4f;
        }
        else if (flips >= 100)
        {
            Flips.fillAmount = 0.2f;
        }
        else if (flips > 0)
        {
            Flips.fillAmount = 0.1f;
        }
        else
        {
            Flips.fillAmount = 0.0f;
        }
    }
}
