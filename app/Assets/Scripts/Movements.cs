

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{



    private Rigidbody2D body;
    private Quaternion rotation;
    public float speed = 15f;
    public float force = 3f;
    public GameObject ButtonA;
    public GameObject ButtonB;
    private Animator anim;
    private bool grounded;
    private float y;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.rotation;
        y = body.velocity.y;
        ButtonA.transform.position = new Vector3(transform.position.x - (2 * Camera.main.orthographicSize) * Camera.main.aspect, transform.position.y, transform.position.z);
        ButtonB.transform.position = new Vector3(transform.position.x + (2 * Camera.main.orthographicSize) * Camera.main.aspect, transform.position.y, transform.position.z);

    }

    private void Update()
    {

        
        ButtonA.transform.position = new Vector3(transform.position.x- (2 * Camera.main.orthographicSize) * Camera.main.aspect, transform.position.y,transform.position.z);
        ButtonB.transform.position = new Vector3(transform.position.x + (2 * Camera.main.orthographicSize) * Camera.main.aspect, transform.position.y, transform.position.z);


        float horizontalInput = Input.GetAxis("Horizontal");
        
        if (horizontalInput == 0) 
        {
            //body.velocity = new Vector2(0,y);
            body.angularVelocity = 0;
        }

        transform.rotation = rotation;
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && grounded)
            jump();

        //flip horizonatally 
        if (horizontalInput > 0.01)
        {

            transform.localScale = new Vector3(0.36936f, 0.36936f, 0.36936f);


        }
        else if (horizontalInput < -0.01)
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