
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DataBank;
using System.Collections.Generic;

public class LoadLevel : MonoBehaviour {
    public string levelName = "Enter level name here";
    private SQLiteHelper helper;

    void Start()
    {
        helper = new SQLiteHelper();
        //helper.createPlayerTable();
        //helper.seePlayerTable();
    }

    public void Load()
    {
        levelName = gameObject.name;
        GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButton>().levelChoosen = levelName;

        Transform infoLevel = gameObject.transform.parent.parent.Find("Info level");

        infoLevel.Find("Level name").GetComponent<Text>().text = levelName;

        List<int> scores = helper.getScores(int.Parse(levelName.Split(' ')[1]), Player.getName());
        scores.Sort();
        int minFlips = 0;
        if (scores.Count > 0)
        {
            minFlips = scores[0];
        }

        infoLevel.Find("Flips").GetComponent<Text>().text = minFlips.ToString();

        if (minFlips > 0)
        {
            infoLevel.Find("Completed").GetComponent<Text>().text = "Yes";
        }
        else
        {
            infoLevel.Find("Completed").GetComponent<Text>().text = "No";
        }

        Play();
    }

    public void Play()
    {
        Transform infoLevel = gameObject.transform.parent.parent.Find("Info level");
        infoLevel.GetComponent<Animator>().SetTrigger("Activate");
    }

    public void Quit()
    {
        Transform infoLevel = gameObject.transform.parent.parent.Find("Info level");
        infoLevel.GetComponent<Animator>().SetTrigger("Desactivate");
    }
}
