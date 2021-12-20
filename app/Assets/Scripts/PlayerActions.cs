using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    public Animator anim;
    public float speed = 15f;
    public float force = 3f;
    private Rigidbody2D myBody;


    private bool moveLeft;
    private bool dontMove;
    private bool canJump;
    private bool isgrounded;

    void Start()
    {
        myBody = GetComponent < Rigidbody2D>();
        dontMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMoving();
    }


    void HandleMoving()
    {
        if (dontMove)
        {
            StopMoving();
        }
        else
        {
            if (moveLeft)
            {
                MoveLeft();
            }
            else if (!moveLeft)
            {
                MoveRigth();
            }
        }
    }





    public void AllowMovement(bool movement) 
    {
        dontMove = false;
        moveLeft = movement;
    }


    public void DontAllowMovement(bool movement)
    {
        dontMove =  true;
    }



    public void StopMoving() 
    {
        anim.SetBool("Move", false);
        myBody.velocity = new Vector2(0f, myBody.velocity.y);
    }

    public void MoveRigth() 
    {
        transform.localScale = new Vector3(0.36936f, 0.36936f, 0.36936f);
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
        anim.SetBool("Move", true);
    }

    public void MoveLeft()
    {
        transform.localScale = new Vector3(-0.36936f, 0.36936f, 0.36936f);
        myBody.velocity = new Vector2(-speed, myBody.velocity.y);
        anim.SetBool("Move", true);
    }

    public void jump()
    {
        if(isgrounded)
        myBody.velocity = new Vector2(myBody.velocity.x,force);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isgrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isgrounded = false;
        }
    }

}

