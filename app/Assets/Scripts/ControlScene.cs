using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enviroment;
    public GameObject kitty;
    public GameObject cane;


    void Start()
    {
        if (Game.worlds[Game.currentWorld].completed == true & Game.worlds[Game.currentWorld].friend == false) //& tmp = true
        {
            enviroment.transform.position = new Vector3(-9.85999966f, -0.529374003f, -10.3579044f);
            kitty.transform.position = new Vector3(-4.692451f, -2.78999996f, -2f);
        }
        else if (Game.worlds[Game.currentWorld].completed == false & Game.worlds[Game.currentWorld].friend == false) //& tmp = true
        {
            //don't move anything
        }
        else if (Game.worlds[Game.currentWorld].completed == true & Game.worlds[Game.currentWorld].friend == true)
        {
            Destroy(cane);
        }


    }



}
