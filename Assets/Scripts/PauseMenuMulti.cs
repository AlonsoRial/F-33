using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuMulti : MonoBehaviour
{
    private PlayerControls playerControls;
    private InputAction menu;



    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject pauseSpeedBarJ1;
    [SerializeField] private GameObject pauseSpeedBarJ2;
    [SerializeField] private bool isPause;

    [SerializeField] private GameObject tempori;



    private Mover mover;

    // Start is called before the first frame update
    void Awake()
    {
      
       
        playerControls = new PlayerControls();

        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseUI.SetActive(false);
        isPause = false;
        pauseSpeedBarJ1.SetActive(true);
        pauseSpeedBarJ2.SetActive(true);

        tempori.SetActive(true);

    }

  

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        

        menu = playerControls.Menu.Escape;

        menu.Enable();

        

        menu.performed += Pause;
    }

    private void OnDisable()
    {
        menu.Disable();
        
    }

    void Pause(InputAction.CallbackContext context) {

        isPause = !isPause;

        if (isPause)
        {
           
            ActivateMenu();
        }
        else {
        
            DeactivateMenu();
            
        }
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseUI.SetActive(true);
        pauseSpeedBarJ2.SetActive(false);
        pauseSpeedBarJ1.SetActive(false);
        tempori.SetActive(false);
        try
        {
           // mover.vibrar = false;
        }
        catch (Exception) { }

        
    }

    public void DeactivateMenu()
    {
        tempori.SetActive(true);
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseUI.SetActive(false);
        isPause = false;
        pauseSpeedBarJ2.SetActive(true);
        pauseSpeedBarJ1.SetActive(true);
    }

    public void GoTitle() {
        SceneManager.LoadScene(0);

    }

    public void ExitGame()
    {

        Application.Quit();
    }


    

    

}
