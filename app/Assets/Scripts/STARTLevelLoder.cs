using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STARTLevelLoder : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator transition;
    // Update is called once per frame



    public void LoadNextLevel()
    {


        if (Game.worlds[0].playedL1 == true) 
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
        }
        else
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

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
}
