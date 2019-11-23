
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {
    public string levelName = "Enter level name here";
    

    public void Load()
    {
        levelName = gameObject.name;
        GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButton>().levelChoosen = levelName;

        Transform infoLevel = gameObject.transform.parent.parent.Find("Info level");

        infoLevel.Find("Level name").GetComponent<Text>().text = levelName;
        infoLevel.Find("Completed").GetComponent<Text>().text = "Non"; // Prendre info de la base de donnée
        infoLevel.Find("Flips").GetComponent<Text>().text = "0"; // Prendre info de la base de donnée

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
