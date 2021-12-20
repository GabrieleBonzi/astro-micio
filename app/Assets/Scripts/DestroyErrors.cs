using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyErrors : MonoBehaviour
{
    public GameObject bouncer;
    private Collision2D collis;
    public GameObject obj;
    public GameObject temp;
    public float timer=1f;

    private void Start() {

        collis = new Collision2D();
        temp = new GameObject();
        obj = temp;
        

    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        collis = coll;
        obj = coll.gameObject;


        if (coll.gameObject.tag == "word")
        {
            SpawnerObjects.choice = SpawnerObjects.spawnPoint;
            bouncer.SetActive(true);
        
                //Destroy(coll.gameObject);
                //bouncer.SetActive(false); 
        }
    }

    private void Update()
    {

        if (timer <= 0 & obj.activeInHierarchy & obj.tag == "word")
        {
            Destroy(collis.gameObject);
            obj = temp;
            timer = 1f;
            bouncer.SetActive(false);
        }


        else if (timer > 0 & obj.activeInHierarchy & obj.tag == "word")
            timer -= Time.deltaTime;
    }



}
