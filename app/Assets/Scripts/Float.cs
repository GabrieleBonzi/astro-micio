

using UnityEngine;
using System.Collections;

// Makes objects float up & down while gently spinning.
public class Float : MonoBehaviour
{
    // User Inputs
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    

    // Position Storage Variables
    Vector3 posOffset = new Vector2();
    Vector3 tempPos = new Vector2();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //// Spin object around Y-Axis
        //transform.Rotate(new Vector2(0f, Time.deltaTime * degreesPerSecond), Space.World);

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
