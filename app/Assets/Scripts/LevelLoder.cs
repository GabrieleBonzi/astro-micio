using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoder : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator transition;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            LoadNextLevel();


        }
    }


    public void LoadNextLevel(){

       StartCoroutine( LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        
    
    
    
 
    
    }

    IEnumerator LoadLevel(int levelIndex) {


        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(1);

        //Load acene
        SceneManager.LoadScene(levelIndex);
    
    }
}
