using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilBar : MonoBehaviour {
    public GUISkin labelSkin;
    private string pseudo;
    private int coins;

    // Use this for initialization
    void Start () {
        labelSkin = Resources.Load<GUISkin>("GUI_skin/Pancake_skin/Gui_skin_Pancake");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        // Compute a fontSize based on the size of the screen width.
        GUI.skin.label.fontSize = (int)(Screen.width / 10.0f);

        GUI.contentColor = Color.red;


        float width = (float)Screen.width;
        float height = (float)Screen.height;
        //GUI.Label(new Rect(width, height, 0, 0));
    }
}
