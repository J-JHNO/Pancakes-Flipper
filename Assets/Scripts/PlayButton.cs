
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {
    public string levelChoosen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        SceneManager.LoadScene(levelChoosen);
    }

    public void Quit()
    {
        SceneManager.LoadScene("GameMenu");
    }
    
}
