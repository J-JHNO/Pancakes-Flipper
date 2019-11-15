
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
    public string levelName = "Enter level name here";
    

    public void Load()
    {
        levelName = gameObject.name;
        GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButton>().levelChoosen = levelName;


        //SceneManager.LoadScene(levelName);
    }
}
