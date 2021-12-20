using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoder : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator transition;
    public int nextLevel;
  
    // Update is called once per frame

 

    public void LoadNextLevel(){

        
      
       StartCoroutine( LoadLevel(nextLevel));
        
    
    
    
 
    
    }

    IEnumerator LoadLevel(int levelIndex) {


        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(1);


            SceneManager.LoadScene(levelIndex);
       
    }
}
