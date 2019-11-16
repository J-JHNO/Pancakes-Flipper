using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using player;

public class LogIn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool check()
    {
        string userName = gameObject.transform.FindChild("User name").GetComponent<Text>().text;
        if (userName.Contains("3"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void correct()
    {
        if (check())
        {
            gameObject.GetComponent<Image>().color = new Color(0, 1, 0, 0.4f); // GREEN
           
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(1, 0, 0, 0.4f); // RED
        }
    }

    public void validation()
    {
        string userName = gameObject.transform.FindChild("User name").GetComponent<Text>().text;
        if (check())
        {
            //((player.Player)gameObject.GetComponent<player.Player>()).build("blabla");

            //player.Player.build("vlavla");
            //player.Player.getInstance();
            //System.Console.Write(player.Player.getName());
            //Debug.Log("test");
            
        }
    }
}
