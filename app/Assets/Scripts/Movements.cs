

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{



    private Rigidbody2D body;
    private Quaternion rotation;
    public float speed = 15f;
    public float force = 3f;
    private Animator anim;
    private bool grounded;


 

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.rotation;
        



    }

    private void Update()
    {


        float horizontalInput = Input.GetAxis("Horizontal");
        
        transform.rotation = rotation;
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && grounded)
            jump();

        //flip horizonatally 
        if (horizontalInput > 0.01)
        {

            transform.localScale = new Vector3(0.36936f, 0.36936f, 0.36936f);


        }
        else if (horizontalInput < 0.01)
        {


            transform.localScale = new Vector3(-0.36936f, 0.36936f, 0.36936f);


        }


        //Anim
        anim.SetBool("Move", horizontalInput != 0);
    }

    private void jump() {

        body.velocity = new Vector2(body.velocity.x, force);
        grounded = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }


}