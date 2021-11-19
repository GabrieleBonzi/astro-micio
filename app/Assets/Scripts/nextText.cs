using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextText : MonoBehaviour
{
    public int numberClicks = 1;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject s;
    public Animator transition;
    public GameObject robot;



    
    public void loadText()
    {

        switch (numberClicks)
        {

            case 1:
                Text1.SetActive(true);
                s.SetActive(true);
                numberClicks++;
                break;
            case 2:
                Text1.transform.localScale = new Vector3(0, 0, 0);
                Text2.transform.localScale = new Vector3(1.09090078f, 1.09090078f, 1.09090078f);
                numberClicks++;
                break;
            case 3:
                Text2.transform.localScale = new Vector3(0, 0, 0);
                Text3.transform.localScale = new Vector3(1.09090078f, 1.09090078f, 1.09090078f);
                numberClicks++;
                break;
            case 4:
                Text3.transform.localScale = new Vector3(0, 0, 0);
                Text4.transform.localScale = new Vector3(1.09090078f, 1.09090078f, 1.09090078f);
                numberClicks++;
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