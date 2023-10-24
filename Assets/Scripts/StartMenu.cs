using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    void Start()
    {
        
    }

    public void SinglePlayer()
    {
        SceneManager.LoadSceneAsync(1);    
    }

    public void MultiPlayer()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
