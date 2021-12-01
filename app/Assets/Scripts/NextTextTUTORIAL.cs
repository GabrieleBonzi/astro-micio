using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextTextTUTORIAL : MonoBehaviour
{

    public static int numberClicks = 1;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject Text5;
    public GameObject s;
    public Animator transition;
    public GameObject robot;
    public GameObject background;
    public  GameObject canvas;


    private void Start()
    {
        
    }

    public void loadText()
    {

        switch (numberClicks)
        {

            //case 1:
            //    Text1.SetActive(true);
                
            //    s.SetActive(true);
            //    numberClicks++;
            //    break;
            case 1:
                Text1.transform.localScale = new Vector3(0, 0, 0);
                Text2.transform.localScale = new Vector3(1.09090078f, 1.09090078f, 1.09090078f);
                numberClicks++;
                break;
            case 2:
                Text2.transform.localScale = new Vector3(0, 0, 0);
                Text3.transform.localScale = new Vector3(1.09090078f, 1.09090078f, 1.09090078f);
                s.SetActive(false);
                background.SetActive(false);
                numberClicks++;
                robot.GetComponent<Animator>().enabled = false;
                canvas.SetActive(false);
                break;
            case 3:
                LoadNextLevel();
                break;
  
        }





    }

    IEnumerator LoadLevel(int levelIndex)
    {


        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(1);

        //Load acene
        SceneManager.LoadScene(levelIndex);

    }




    public void LoadNextLevel()
    {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));






    }

    private void Update()
    {

    }

}