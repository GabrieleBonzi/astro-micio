using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuUI;
    public Animator transition;
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;


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

    public void Stats() 
    {
       
            PauseMenuUI.SetActive(true); //Gameobject activated
            s1.SetActive(true);
            s2.SetActive(true);
            s3.SetActive(true);
            Time.timeScale = 0f; //freeze the game
    }

    public void StopStats()
    {
        PauseMenuUI.SetActive(false); //Gameobject deactivated
        s1.SetActive(false);
        s2.SetActive(false);
        s3.SetActive(false);
        Time.timeScale = 1f; //normal speed


    }



    public void del()
    {

        PauseMenuUI.SetActive(true); //Gameobject activated
    }

    public void Stopdel()
    {
        PauseMenuUI.SetActive(false); //Gameobject deactivated
    }


    public void LoadMenu()
    {
        Time.timeScale = 1f;
        LoadNextLevel("Map");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Start");
    }

    public void CancelProgress() 
    {
        Game.DeleteSaveings();
        LoadNextLevel("Start");
    }


    public void FirstWorld()
    {
        Time.timeScale = 1f;

        if(Game.worlds[Game.currentWorld].friend == false) 
        {
            LoadNextLevel("FirstWord");
        }
        else
        {
            SceneManager.LoadScene("Map");
        }
        
    }

    public void SecondWorld()
    {
        Time.timeScale = 1f;
        if (Game.worlds[Game.currentWorld].friend == false)
        {
            LoadNextLevel("SecondWorld");
        }
        else
        {
            SceneManager.LoadScene("Map");
        }
    }

    public void ThirdWorld()
    {
        Time.timeScale = 1f;
        if (Game.worlds[Game.currentWorld].friend == false)
        {
            LoadNextLevel("ThirdWorld");
        }
        else
        {
            SceneManager.LoadScene("Map");
        }
    }


    public void LoadNextLevel(string world)
    {



        StartCoroutine(LoadLevel(world));






    }

    IEnumerator LoadLevel(string levelIndex)
    {


        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(1);


        SceneManager.LoadScene(levelIndex);

    }

}
