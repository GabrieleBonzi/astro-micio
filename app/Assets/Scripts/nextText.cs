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

    //audio 
    public AudioSource speaker;
    public AudioClip audio1;
    public AudioClip audio2;
    public AudioClip audio3;
    public AudioClip audio4;
    


    private void Start()
    {
        robot.GetComponent<Animator>().enabled = false;
    }

    public void loadText()
    {

        switch (numberClicks)
        {

            case 1:
                Text1.SetActive(true);
                robot.GetComponent<Animator>().enabled = true;
                s.SetActive(true);
                speaker.Stop();
                speaker.PlayOneShot(audio1);
                numberClicks++;
                break;
            case 2:
                Text1.transform.localScale = new Vector3(0, 0, 0);
                Text2.transform.localScale = new Vector3(1.09090078f, 1.09090078f, 1.09090078f);
                speaker.Stop();
                speaker.PlayOneShot(audio2);
                numberClicks++;
                break;
            case 3:
                Text2.transform.localScale = new Vector3(0, 0, 0);
                Text3.transform.localScale = new Vector3(1.09090078f, 1.09090078f, 1.09090078f);
                speaker.Stop();
                speaker.PlayOneShot(audio3);
                numberClicks++;
                break;
            case 4:
                Text3.transform.localScale = new Vector3(0, 0, 0);
                Text4.transform.localScale = new Vector3(1.09090078f, 1.09090078f, 1.09090078f);
                speaker.Stop();
                speaker.PlayOneShot(audio4);
                numberClicks++;
                
                break;
            case 5:

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