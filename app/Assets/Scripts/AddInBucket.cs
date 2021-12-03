using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInBucket : MonoBehaviour
{
    public GameObject bouncer;
    public static float timer = 0.5f;
    public static bool destroyed = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "word")
        {
            SpawnerObjects.choice = transform.position;
            Destroy(col.gameObject);
            bouncer.SetActive(false);
            destroyed = true;
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
    }
}


