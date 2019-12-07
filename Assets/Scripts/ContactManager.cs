using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataBank;

public class ContactManager : MonoBehaviour {
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

    public void ShowInvites()
    {
        //ListItemControler liste = gameObject.transform.parent.Find("Friends List").Find("Friends").GetComponent<ListItemControler>();
        ListItemControler liste = GameObject.FindGameObjectWithTag("FriendContainer").GetComponent<ListItemControler>();
        liste.refreshInvite();
    }

    public void ShowFriends()
    {

        //ListItemControler liste = gameObject.transform.parent.Find("Friends List").Find("Friends").GetComponent<ListItemControler>();
        ListItemControler liste = GameObject.FindGameObjectWithTag("FriendContainer").GetComponent<ListItemControler>();
        liste.refreshFriends();
    }

    public void AddFriend()
    {
        Text pseudo = gameObject.transform.parent.Find("Pseudo").GetComponent<Text>();
        helper.approveFriend(Player.getName(), pseudo.text);

        ShowInvites();
    }

    public void DeclineInvite()
    {
        Text pseudo = gameObject.transform.parent.Find("Pseudo").GetComponent<Text>();
        helper.declineFriend(Player.getName(), pseudo.text);

        ShowInvites();
    }

    public void DeleteFriend()
    {
        Text pseudo = gameObject.transform.parent.Find("Pseudo").GetComponent<Text>();
        helper.removeFriend(Player.getName(), pseudo.text);

        ShowFriends();
    }

    public void ProvocFriend()
    {

    }

    public void SendRequest()
    {
        string userName = gameObject.transform.parent.Find("InputField").Find("User name").GetComponent<Text>().text;
        // Debug.Log("test : " + userName);
        bool r = helper.playerExists(userName);

        if (r)
        {
            gameObject.transform.parent.Find("InputField").Find("User name").GetComponent<Text>().text = "";
            helper.addPlayerToWaiting(Player.getName(), userName);

            gameObject.transform.parent.parent.parent.Find("Bottom").Find("Info invite").GetComponent<Text>().text = "Invite send !";
        }
        else
        {
            gameObject.transform.parent.parent.parent.Find("Bottom").Find("Info invite").GetComponent<Text>().text = "This player doesn't exist";

            Debug.Log(userName + "Doesn't exists");
        }
    }

    public bool check()
    {
        //helper.open();
        string userName = gameObject.transform.Find("User name").GetComponent<Text>().text;
        // Debug.Log("test : " + userName);
        bool r = helper.playerExists(userName);
        // helper.close();
        return r;
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
        string userName = gameObject.transform.Find("User name").GetComponent<Text>().text;
        if (check())
        {
            gameObject.transform.Find("User name").GetComponent<Text>().text = "";
            helper.addPlayerToWaiting(Player.getName(), userName);
        }
        else
        {
            Debug.Log(userName + "Doesn't exists");
        }
    }
}
