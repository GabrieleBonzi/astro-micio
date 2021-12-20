using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mov_jump_touch : MonoBehaviour
{


    [SerializeField]
    float moveSpeed = 5f;

    Rigidbody2D rb;

    Touch touch;
    Vector3 touchPosition, whereToMove;
    bool isMoving = false;
    private Quaternion rot;
    private float y;
    private Animator anim;
    private bool isgrounded;
    private bool moved;
    public float jumpForce = 9.5f;
    private float timePressed = 0.0f;
    private float timeLastPress = 0.0f;
    public float thr = 0.1f;

    float previousDistanceToTouchPos, currentDistanceToTouchPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        y = rb.transform.position.y;
        rot = transform.rotation;
        whereToMove = transform.position;
    }

    void FixedUpdate()
    {
        transform.rotation = rot;
        if (isMoving)
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isMoving = true;
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                whereToMove = (touchPosition - transform.position).normalized;
                if (whereToMove.x > 0)
                {
                    transform.localScale = new Vector3(0.36936f, 0.36936f, 0.36936f);
                }
                else
                {
                    transform.localScale = new Vector3(-0.36936f, 0.36936f, 0.36936f);
                }
                rb.velocity = new Vector2(whereToMove.x * moveSpeed, 0);

                //ADDED FOR JUMP
               timePressed = Time.time - timeLastPress;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                timeLastPress = Time.time;
            }

            //ADDED FOR JUMP
            if (timePressed < thr && isgrounded == true)
            {

                Debug.Log("dio bo");
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

        }

        if (currentDistanceToTouchPos > previousDistanceToTouchPos)
        {
            isMoving = false;
        }

        if (isMoving)
        {
            previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
            
        }
        //else
        //{
        //    rb.velocity = new Vector2(0, 0);
        //}

        // ADDED FOR STAYING IN THE SCENE
        anim.SetBool("Move", isMoving);
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