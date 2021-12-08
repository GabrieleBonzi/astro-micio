using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onlyJump : MonoBehaviour
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
	private bool grounded;
	private bool moved;
	private float jumpForce = 10f;
	private float timePressed = 0.0f;
	private float timeLastPress = 0.0f;
	private float thr = 0.5f;

	float previousDistanceToTouchPos, currentDistanceToTouchPos;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		y = rb.transform.position.y;
		rot = transform.rotation;
		whereToMove = transform.position;
	}

	void Update()
	{

		//transform.rotation = rot;
		//if (isMoving)
		//	currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;

		if (Input.touchCount > 0)
		{
			//Debug.Log("touch count" + Input.touchCount);
			touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began)
			{
				//previousDistanceToTouchPos = 0;
				//currentDistanceToTouchPos = 0;
				//isMoving = true;
				//touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
				//touchPosition.z = 0;
				////if (whereToMove.x > 0)
				////            {
				////	transform.localScale = new Vector3(0.36936f, 0.36936f, 0.36936f);
				////}
				////            else
				////            {
				////	transform.localScale = new Vector3(-0.36936f, 0.36936f, 0.36936f);
				////}
				////Debug.Log("touch position " + touchPosition.x);
				////Debug.Log("wheretomove " + whereToMove.x);
				//whereToMove = (touchPosition - transform.position).normalized;
				//if (whereToMove.x > 0)
				//{
				//	transform.localScale = new Vector3(0.36936f, 0.36936f, 0.36936f);
				//}
				//else
				//{
				//	transform.localScale = new Vector3(-0.36936f, 0.36936f, 0.36936f);
				//}
				//rb.velocity = new Vector2(whereToMove.x * moveSpeed, 0);

				// ADDED FOR JUMP
				timePressed = Time.time - timeLastPress;
				//Debug.Log(timePressed);
			}
			if (touch.phase == TouchPhase.Ended)
			{
				timeLastPress = Time.time;
			}

			// ADDED FOR JUMP
			if (timePressed < thr)
			{
				Debug.Log("jump! timer " + timePressed);
				//rb.velocity = new Vector2(0, 0);
				//rb.velocity = new Vector2(rb.velocity.x, jumpForce);
				rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			}
		}

		//if (currentDistanceToTouchPos > previousDistanceToTouchPos)
		//{
		//	isMoving = false;
		//	rb.velocity = Vector2.zero;
		//}

		//if (isMoving)
		//{
		//	previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
		//	anim.SetBool("Move", touch.phase != TouchPhase.Ended);
		//}
	}
}