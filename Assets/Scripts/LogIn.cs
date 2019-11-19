using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using player;
using DataBank;

public class LogIn : MonoBehaviour {
	private SQLiteHelper helper;
	// Use this for initialization
	void Start () {
		helper=new SQLiteHelper();
		helper.createPlayerTable();
		helper.seePlayerTable();
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
			if(helper.playerExists(userName)){
				helper.addPlayer(userName);
			}
			else{
				Debug.Log(userName+"Already exists");
			}
			helper.seePlayerTable();
			
            //player.Player.build("vlavla");
            //player.Player.getInstance();
            //System.Console.Write(player.Player.getName());
            //Debug.Log("test");
            
        }
    }
}
