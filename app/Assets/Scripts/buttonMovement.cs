using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonMovement : MonoBehaviour
{

    public GameObject kitty;
    public GameObject ButtonA;
    public GameObject ButtonB;
    public GameObject ButtonC;
    // Start is called before the first frame update
    void Start()
    {
        ButtonA.transform.position = new Vector3(kitty.transform.position.x  , kitty.transform.position.y, kitty.transform.position.z);
        ButtonB.transform.position = new Vector3(kitty.transform.position.x, kitty.transform.position.y, kitty.transform.position.z);
        ButtonC.transform.position = new Vector3(kitty.transform.position.x, kitty.transform.position.y, kitty.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (kitty!=null)
        {
            ButtonA.transform.position = new Vector3(kitty.transform.position.x, kitty.transform.position.y, kitty.transform.position.z);
            ButtonB.transform.position = new Vector3(kitty.transform.position.x, kitty.transform.position.y, kitty.transform.position.z);
            ButtonC.transform.position = new Vector3(kitty.transform.position.x, kitty.transform.position.y, kitty.transform.position.z);
        }
        }
}
