using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectFriend : MonoBehaviour
{
    public Animator transition;
    public AudioSource speaker;
    public AudioSource speaker2;
    private bool first;

    private void Start() 
    {
        first = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        
        if (col.gameObject.tag == "Player")
        {
            Game.CollectFriend();
            Game.SaveGameInfo();
            if (first == true)
            {
                speaker.Play();
                speaker2.Play();
                first = false;
            }
            StartCoroutine(LoadMAP());
            

        }




        IEnumerator LoadMAP()
        {
            //Wait
            yield return new WaitForSeconds(10);

            //Play Animation
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(1);


            //Load acene
            SceneManager.LoadScene("Map");

        }

    }
}
