

using UnityEngine;
using System.Collections;

// Makes objects float up & down while gently spinning.
public class FloatText : MonoBehaviour
{
    // User Inputs
    public float degreesPerSecond = 15.0f;
    public float amplitude = 10f;
    public float frequency = 1f;
    public RectTransform TextObject;
    private Vector2 position;


    // Position Storage Variables
    private float tempPos;
    private RectTransform rt;

    // Use this for initialization
    void Awake()
    {
        // Store the starting position & rotation of the object
        
        rt = TextObject.GetComponent(typeof(RectTransform)) as RectTransform;
        position = rt.anchoredPosition;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //// Spin object around Y-Axis
        //transform.Rotate(new Vector2(0f, Time.deltaTime * degreesPerSecond), Space.World);

        // Float up/down with a Sin()

        tempPos = position.y;
        tempPos += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        rt.anchoredPosition = new Vector2(position.x, tempPos);
    }
}
