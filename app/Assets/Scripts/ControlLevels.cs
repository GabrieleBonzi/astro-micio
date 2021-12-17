using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlLevels : MonoBehaviour
{

    public GameObject w1;
    public GameObject w2;
    public GameObject w3;

    // Start is called before the first frame update
    void Start()
    {
        if (Game.worlds[0].completed == true & Game.worlds[0].friend == true ) 
        {
            w2.GetComponent<Button>().interactable = true;
        }


        if (Game.worlds[1].completed == true & Game.worlds[0].friend == true)
        {
            w3.GetComponent<Button>().interactable = true;
        }
    }

    // Update is called once per frame

}
