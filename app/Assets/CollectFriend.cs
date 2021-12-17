using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectFriend : MonoBehaviour
{
    public Animator transition;
    void OnTriggerEnter2D(Collider2D col)
    {

        Debug.Log(Game.currentWorld);
        if (col.gameObject.tag == "Player")
        {
            Game.CollectFriend();
            Game.SaveGameInfo();
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
