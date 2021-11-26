

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
       // Debug.Log(body.velocity);

        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, force);

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




    //Rigidbody2D m_Rigidbody;
    //public float m_Speed = 5f;

    //void Start()
    //{
    //    //Fetch the Rigidbody from the GameObject with this script attached
    //    m_Rigidbody = GetComponent<Rigidbody2D>();
    //}

    //void FixedUpdate()
    //{
    //    Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
    //    //Debug.Log(pos);
    //    pos.x = Mathf.Clamp01(pos.x);
    //    pos.y = Mathf.Clamp01(pos.y);
    //    //Store user input as a movement vector
    //    Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);

    //    //Apply the movement vector to the current position, which is
    //    //multiplied by deltaTime and speed for a smooth MovePosition
    //    m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
    //}

}