using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuUI;
  


    // Update is called once per frame

    public void Resume()
    {
        PauseMenuUI.SetActive(false); //Gameobject deactivated
        Time.timeScale = 1f; //normal speed
    
        
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true); //Gameobject activated
        Time.timeScale = 0f; //freeze the game
     
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Map");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting menu...");
        Application.Quit();
    }
}


