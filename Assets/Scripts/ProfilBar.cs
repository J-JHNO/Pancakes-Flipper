using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataBank;

public class ProfilBar : MonoBehaviour {
    private string pseudo;
    private int coins;

    private SQLiteHelper helper;

    // Use this for initialization
    void Start () {
        helper = new SQLiteHelper();
        //helper.createPlayerTable();
        //helper.seePlayerTable();


        pseudo = Player.getName();
        Text userName = (Text)gameObject.transform.Find("UserName").GetComponent<Text>();
        userName.text = pseudo;
        coins = helper.getTotalPlayerFlips(Player.getName());

        gameObject.transform.Find("PancakeCoins").Find("Value").GetComponent<Text>().text = coins.ToString();
        Debug.Log("coins :" + coins + " / DB :" + helper.getTotalPlayerFlips(Player.getName()));
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    
}
