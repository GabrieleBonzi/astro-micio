using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInBucket : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "word")
        Debug.Log(gameObject.name + " Collided");
        Destroy(col.gameObject);
    }
}


