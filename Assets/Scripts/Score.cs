using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
