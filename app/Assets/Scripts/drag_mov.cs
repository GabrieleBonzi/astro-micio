using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_mov : MonoBehaviour
{
    private bool _moved;
    private float speed = 0.5f;
    private float jumpForce = 10f;

    private void Update()
    {
        //Mobile Touch Drag Controls
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across X plane
            transform.Translate(touchDeltaPosition.x * speed, 0, 0);
            _moved = true; // Remember that the player moved
        }


        ////Mobile Touch To Jump
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if (!_moved) // Only jump if we didnt move
            {
                transform.Translate(Vector3.up * jumpForce * Time.deltaTime, Space.World);
            }
            _moved = false;
        }
    }
}
