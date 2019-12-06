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
        helper.seePlayerTable();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowInvites()
    {
        //Transform parent = gameObject.transform.parent;
       // Transform content = parent.Find("Friends List").Find("Viewport").Find("Content");
        GameObject[] childs = GameObject.FindGameObjectsWithTag("Friend");
        //Transform test = childs[0].Find("Defier");
        foreach (GameObject child in childs)
        {
            Transform defier = child.transform.Find("Defier");
            defier.transform.transform.localScale = new Vector3(0, 0, 0);
            Transform ajouter = child.transform.Find("Ajouter");
            ajouter.transform.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void ShowFriends()
    {
        //Transform parent = gameObject.transform.parent;
        // Transform content = parent.Find("Friends List").Find("Viewport").Find("Content");
        GameObject[] childs = GameObject.FindGameObjectsWithTag("Friend");
        foreach (GameObject child in childs)
        {
            Transform defier = child.transform.Find("Defier");
            defier.transform.transform.localScale = new Vector3(1, 1, 1);
            Transform ajouter = child.transform.Find("Ajouter");
            ajouter.transform.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    public void AddFriend()
    {
        string userName = gameObject.transform.parent.Find("InputField").Find("User name").GetComponent<Text>().text;
        // Debug.Log("test : " + userName);
        bool r = helper.playerExists(userName);

        if (r)
        {
            gameObject.transform.Find("User name").GetComponent<Text>().text = "";
        }
        else
        {
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
        // helper.open();
        string userName = gameObject.transform.Find("User name").GetComponent<Text>().text;
        if (check())
        {
            //helper.addPlayer(userName);
            gameObject.transform.Find("User name").GetComponent<Text>().text = "";
        }
        else
        {
            Debug.Log(userName + "Doesn't exists");
        }
        //helper.seePlayerTable();
        //helper.close();
    }
}
