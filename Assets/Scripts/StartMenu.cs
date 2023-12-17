using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = false;
        AudioListener.pause = false;
 
    }

    public void SinglePlayer()
    {
        SceneManager.LoadSceneAsync(1);    
    }

    public void MultiPlayer()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Creditos()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void Controles()
    {
        SceneManager.LoadSceneAsync(7);
    }

    public void CerrarCreditos()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
