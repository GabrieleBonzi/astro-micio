using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadIntro2 : MonoBehaviour
{

    public float Timer;
   

    public Animator transition;
    public int nextLevel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0) 
        {
            LoadNextLevel();
        }
    }




    // Update is called once per frame



    public void LoadNextLevel()
    {



        StartCoroutine(LoadLevel(nextLevel));






    }

    IEnumerator LoadLevel(int levelIndex)
    {


        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(1);


        SceneManager.LoadScene(levelIndex);

    }
}
