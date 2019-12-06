
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DataBank;

public class LogIn : MonoBehaviour {
    private SQLiteHelper helper;

    // Use this for initialization
    void Start()
    {
        Transform parent = gameObject.transform.parent;
        Transform waitingText = ((Transform)parent.transform.Find("Waiting"));
        waitingText.gameObject.SetActive(false);

        helper = new SQLiteHelper();
        //helper.createPlayerTable();
        helper.seePlayerTable();

    }
	
	// Update is called once per frame
	void Update () {
    }

    public bool check()
    {
        //helper.open();
        string userName = gameObject.transform.Find("User name").GetComponent<Text>().text;
       // Debug.Log("test : " + userName);
        bool r = !helper.playerExists(userName);
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
            helper.addPlayer(userName);
        }
        else
        {
            Debug.Log(userName + "Already exists");
        }
        //helper.seePlayerTable();
        //helper.close();

         Player.setName(userName);





        
        Transform intro = (gameObject.transform.parent).Find("Introduction");
        intro.GetComponent<Text>().text = "Welcome " + Player.getName();

        gameObject.SetActive(false);

        Transform parent = gameObject.transform.parent;
        Transform waitingText = ((Transform)parent.transform.Find("Waiting"));
        waitingText.gameObject.SetActive(true);


        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Home");
        LoadingScreen.Instance.Show(asyncLoad);





    }
}
