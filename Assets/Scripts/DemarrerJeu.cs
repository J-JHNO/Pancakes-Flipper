using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemarrerJeu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void demarrerJeu()
    {
        SceneManager.LoadScene("GameMenu");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
