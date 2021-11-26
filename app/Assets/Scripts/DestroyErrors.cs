using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyErrors : MonoBehaviour
{
    
  
    void OnCollisionEnter2D(Collision2D coll)
    {


        
        if (coll.gameObject.tag == "word")
        {
            SpawnerObjects.choice = SpawnerObjects.spawnPoint;
            Destroy(coll.gameObject);
            
        }
    }
}
