using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInBucket : MonoBehaviour
{
    public GameObject bouncer;
    public static float timer = 0.5f;
    public static float timerHelp = 7f;
    public static bool destroyed;
    public static bool dialogue;
    public static bool corr;


    private void Awake() 
    {
        destroyed = false;
        dialogue = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "word")
        {
            SpawnerObjects.choice = transform.position;
            Destroy(col.gameObject);
            bouncer.SetActive(false);
            destroyed = true;
            dialogue = true;
        }
        
    }

    private void Update()
    {
        if (destroyed == true & timer > 0)
        {

            timer -= Time.deltaTime;
 
        }
        else if(destroyed == true & timer < 0) 
        { 
            destroyed = false;
            timer = 1;
            
        }

        

        if (dialogue == true & timerHelp > 0)
        {

            
            timerHelp -= Time.deltaTime;
            
        }
        else if (dialogue == true & timerHelp < 0)
        {
            dialogue = false;
            timerHelp = 7f;

        }



    }
}


