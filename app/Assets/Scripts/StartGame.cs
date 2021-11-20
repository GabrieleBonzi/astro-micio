using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator transition;
    
    // Update is called once per frame
    void Update()
    {

    }
     void OnCollisionEnter2D(Collision2D coll)
        {


        Debug.Log("Collided with: " );
        if (coll.gameObject.name == "kitty")
            {
                Destroy(coll.gameObject);
            LoadNextLevel();
            }
        }

  


    public void LoadNextLevel()
    {

        StartCoroutine(LoadLevel(4));






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
