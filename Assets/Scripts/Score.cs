using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using fuck = System.Diagnostics;
using System;
using System.Threading;

public class Score : MonoBehaviour
{
    private Vector3 position;
    private float width;
    private float height;
    public int flips = 0;
    public GUISkin labelSkin;



    void Start()
    {
        labelSkin = Resources.Load<GUISkin>("GUI_skin/Pancake_skin/Gui_skin_Pancake2");

        /*Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        Thread.Sleep(10000);
        stopWatch.Stop();
        
        TimeSpan ts = stopWatch.Elapsed;*/

        //TimeSpan hi = new TimeSpan(2,3,4);
        //ebug.Log(hi.Minutes);


        //helper.createLevelTable(1);
        //helper.addScore(1,"Boyan",100,ts);

        //foreach(TimeSpan i in helper.getTimes(1, "Boyan")){
        //	Debug.Log(i.ToString());
        //}
    }

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        // Position used for the cube.
        position = new Vector3(0.0f, 0.0f, 0.0f);

        
    }

    void OnGUI()
    {
        // Compute a fontSize based on the size of the screen width.
        GUI.skin.label.fontSize = (int)(Screen.width / 10.0f);

        GUI.contentColor = Color.blue;


        // GUILayout.Label("FLIPS = " + flips.ToString(), labelSkin.GetStyle("Pancake_style"));

        GUI.Label(new Rect(40, 40, width * 1.75f, height * 0.5f),"Flips = " + flips.ToString(), labelSkin.GetStyle("Pancake_style_2"));
    }

}
