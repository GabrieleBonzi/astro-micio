using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObject : MonoBehaviour
{

    public float thrust = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.up);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.gameObject.tag == "word")
        {
            col.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust, ForceMode2D.Impulse);
            Debug.Log(transform.up);


        }
    }
}
