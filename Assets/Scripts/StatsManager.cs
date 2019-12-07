using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using UnityEngine.UI;
using System;
using System.Globalization;

public class StatsManager : MonoBehaviour {
    private SQLiteHelper helper;

    // Use this for initialization
    void Start () {
        helper = new SQLiteHelper();
        //helper.createPlayerTable();
        //helper.seePlayerTable();

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        helper = new SQLiteHelper();
        //helper.createPlayerTable();
       // helper.seePlayerTable();

        int flips = SumFlips();
        RefreshFlips(flips);


        TimeSpan temps = TotalTime();
        RefreshTime(temps);

        Debug.Log(flips + " / " + temps);
    }

    int SumFlips()
    {
        int flips = 0;
        int numberLevels = 3;
        for (int i=1; i<=numberLevels; i++)
        {
            List<int> scores = null;
            scores = helper.getScores(i, Player.getName());
            if (scores != null && scores.Count != 0)
            {
                for (int j = 0; j < scores.Count; j++)
                {
                    flips += scores[j];
                }
            }
            
        }
        return flips;
    }

    int MinTime()
    {
        int numberLevels = 3;
        int minTime = -1;
        for (int i = 1; i <= numberLevels; i++)
        {
            List<TimeSpan> times = null;
            times = helper.getTimes(i, Player.getName());
            if (times != null && times.Count != 0)
            {
                for (int j = 0; j < times.Count; j++)
                {
                    int time = (int)times[j].TotalSeconds;
                    if (minTime < 0)
                    {
                        minTime = time;
                    }
                    else
                    {
                        if (time < minTime)
                        {
                            minTime = time;
                        }
                    }
                }
            }
            
        }

        return minTime;
    }

    TimeSpan TotalTime()
    {
        int numberLevels = 3;
        TimeSpan time = new TimeSpan(0,0,0);
        for (int i = 1; i <= numberLevels; i++)
        {
            List<TimeSpan> times = null;
            times = helper.getTimes(i, Player.getName());
            if (times != null && times.Count != 0)
            {
                foreach ( TimeSpan T in times)
                {
                    Debug.Log("qdded "+T);
                    TimeSpan t = time.Add(T);
                    time = t;
                    Debug.Log("time : " + time);
                }
                
            }

        }
        
        return time;
    }

    void RefreshFlips(int flips)
    {
        Image Flips = gameObject.transform.Find("Flips").Find("RadialFill").Find("Fill image").GetComponent<Image>();
        Text Desc = gameObject.transform.Find("Flips").Find("Description").GetComponent<Text>();
        Text Info = gameObject.transform.Find("Flips").Find("RadialFill").Find("Center").Find("Display text").GetComponent<Text>();
        Info.text = flips.ToString();
        if (flips >= 1000000)
        {
            Flips.fillAmount = 1.0f;
            Desc.text = "Legendaire";
        }
        else if (flips >= 100000)
        {
            Flips.fillAmount = 0.8f;
            Desc.text = "Expert";
        }
        else if (flips >= 10000)
        {
            Flips.fillAmount = 0.6f;
            Desc.text = "Pro";
        }
        else if (flips >= 1000)
        {
            Flips.fillAmount = 0.4f;
            Desc.text = "Avance";
        }
        else if (flips >= 100)
        {
            Flips.fillAmount = 0.2f;
            Desc.text = "Intermediaire";
        }
        else if (flips > 0)
        {
            Flips.fillAmount = 0.1f;
            Desc.text = "Amateur";
        }
        else
        {
            Flips.fillAmount = 0.0f;
            Desc.text = "Debutant";
        }
    }

    void RefreshTime(TimeSpan time) // en secondes
    {
        Image Time = gameObject.transform.Find("Time").Find("RadialFill").Find("Fill image").GetComponent<Image>();
        Text Desc = gameObject.transform.Find("Time").Find("Description").GetComponent<Text>();
        Text Info = gameObject.transform.Find("Time").Find("RadialFill").Find("Center").Find("Display text").GetComponent<Text>();
        Info.text = time.Hours + ":" + time.Minutes + ":" + time.Seconds;

        int temps = (int)time.TotalSeconds;
        if (temps < 0)
        {
            Time.fillAmount = 0.0f;
            Desc.text = "Debutant";
        }
        else if (temps <= 30)
        {
            Time.fillAmount = 1.0f;
            Desc.text = "Legendaire";
            
        }
        else if (temps <= 60)
        {
            Time.fillAmount = 0.8f;
            Desc.text = "Expert";
           
        }
        else if (temps <= 90)
        {
            Time.fillAmount = 0.6f;
            Desc.text = "Pro";
            
        }
        else if (temps <= 120)
        {
            Time.fillAmount = 0.4f;
            Desc.text = "Avance";
            
        }
        else if (temps <= 360)
        {
            Time.fillAmount = 0.2f;
            Desc.text = "Intermediaire";
            
        }
        else if (temps <= 480)
        {
            Time.fillAmount = 0.1f;
            Desc.text = "Amateur";
        }
        else
        {
            Time.fillAmount = 0.0f;
            Desc.text = "Debutant";
        }
    }
}
