using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator transition;
    public int next_scene;
    
    // Update is called once per frame
    void Update()
    {

    }
     void OnCollisionEnter2D(Collision2D coll)
        {


        
        if (coll.gameObject.name == "kitty")
            {
                Destroy(coll.gameObject);
            LoadNextLevel();
            }
        }

  


    public void LoadNextLevel()
    {

        StartCoroutine(LoadLevel(next_scene));






    }

    IEnumerator LoadLevel(int levelIndex)
    {


        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(1);

        var lev = levelIndex + 1;
   
        //Load acene
        if (Game.worlds[Game.currentWorld].playedL1 == true)
        {
            
            SceneManager.LoadScene(lev);
        }
        else if (Game.worlds[Game.currentWorld].playedL1 == false)
        {
            SceneManager.LoadScene(levelIndex);
        }

    }
}
