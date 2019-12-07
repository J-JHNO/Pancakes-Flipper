using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataBank;


public class ListItemControler : MonoBehaviour {
    public GameObject ContentPanel;
    public GameObject ListItemPrefabFriend;
    public GameObject ListItemPrefabInvite;
    private SQLiteHelper helper;

    ArrayList Friends;

    // Use this for initialization
    void Start () {
        helper = new SQLiteHelper();
        //helper.createPlayerTable();
       // helper.seePlayerTable();

        // CREATE TABLE
        //helper.createFriendsTable();
        //helper.createWaitingFriendsTable();

        //ADDING FRIENDS
        /*helper.addPlayerToWaiting("Poulet",Player.getName());
        helper.addPlayerToWaiting(Player.getName(), "Boyan");
        helper.approveFriend("Boyan", Player.getName());
        helper.addPlayerToWaiting(Player.getName(), "Steph");
        helper.approveFriend("Steph", Player.getName());*/

        List<string> friendList = helper.getApprovedFriends(Player.getName());
        

        foreach (string player in friendList)
        {
            GameObject newPlayer = Instantiate(ListItemPrefabFriend) as GameObject;
            ListControler controller = newPlayer.GetComponent<ListControler>();
            Debug.Log(controller);
            controller.pseudo.text = player;
            newPlayer.transform.parent = ContentPanel.transform;
            newPlayer.transform.localScale = Vector3.one;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void refreshFriends()
    {
        // DELETE BEFORE
        GameObject[] invites = GameObject.FindGameObjectsWithTag("Invite");
        foreach (GameObject invite in invites)
        {
            Destroy(invite);
        }

        GameObject[] friends = GameObject.FindGameObjectsWithTag("Friend");
        foreach (GameObject friend in friends)
        {
            Destroy(friend);
        }

        // ADDING 
        List<string> friendList = helper.getApprovedFriends(Player.getName());
        foreach (string player in friendList)
        {
            GameObject newPlayer = Instantiate(ListItemPrefabFriend) as GameObject;
            ListControler controller = newPlayer.GetComponent<ListControler>();
            Debug.Log(controller);
            controller.pseudo.text = player;
            newPlayer.transform.parent = ContentPanel.transform;
            newPlayer.transform.localScale = Vector3.one;
        }
    }

    public void refreshInvite()
    {
        // DELETE BEFORE
        GameObject[] friends = GameObject.FindGameObjectsWithTag("Friend");
        foreach (GameObject friend in friends)
        {
            Destroy(friend);
        }

        GameObject[] invites = GameObject.FindGameObjectsWithTag("Invite");
        foreach (GameObject invite in invites)
        {
            Destroy(invite);
        }

        // ADDING 
        List<string> friendListWait = helper.getFriendRequests(Player.getName());
        foreach (string player in friendListWait)
        {
            GameObject newPlayer = Instantiate(ListItemPrefabInvite) as GameObject;
            ListControler controller = newPlayer.GetComponent<ListControler>();
            Debug.Log(controller);
            controller.pseudo.text = player;
            newPlayer.transform.parent = ContentPanel.transform;
            newPlayer.transform.localScale = Vector3.one;
        }
    }
}
