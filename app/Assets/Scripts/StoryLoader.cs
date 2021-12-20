using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StoryLoader : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator transition;
    // Update is called once per frame


    public void LoadNextLevel()
    {

        StartCoroutine(LoadLevel(1));






    }

    IEnumerator LoadLevel(int levelIndex)
    {
        Debug.Log(levelIndex);

        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(1);

        //Load acene
        SceneManager.LoadScene(levelIndex);

    }
}
