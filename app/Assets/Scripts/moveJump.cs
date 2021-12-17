using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveJump : MonoBehaviour
{
	[SerializeField]

	Rigidbody2D rb;

	Touch touch;
	private Quaternion rot;
	private float y;
	private bool isgrounded;
	public float jumpForce = 9.5f;
	private float timePressed = 0.0f;
	private float timeLastPress = 0.0f;
	public float thr = 0.1f;

	float previousDistanceToTouchPos, currentDistanceToTouchPos;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		y = rb.transform.position.y;
		rot = transform.rotation;
	}

	void Update()
	{
		transform.rotation = rot;

		if (Input.touchCount > 0)
		{
			touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began)
			{
				timePressed = Time.time - timeLastPress;
			}
			if (touch.phase == TouchPhase.Ended)
			{
				timeLastPress = Time.time;
			}

			if (timePressed < thr && isgrounded == true)
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			}

		}

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
