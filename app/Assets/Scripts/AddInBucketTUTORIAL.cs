using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInBucketTUTORIAL : MonoBehaviour
{
    public GameObject bouncer;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "word")
        {
            SpawnerObjectsTUTORIALWorld1.choice = transform.position;
            Destroy(col.gameObject);
            bouncer.SetActive(false);
           
        }

    }
}


