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
        if (Game.worlds[0].completed == true & Game.worlds[0].friend == false) //& tmp = true
        {
            enviroment.transform.position = new Vector3(-9.85999966f, -0.529374003f, -10.3579044f);
            kitty.transform.position = new Vector3(-6.76999998f, -2.78999996f, -2f);
        }
        else if (Game.worlds[0].completed == false & Game.worlds[0].friend == false) //& tmp = true
        {
            //don't move anything
        }
        else if (Game.worlds[0].completed == true & Game.worlds[0].friend == true)
        {
            Destroy(cane);
        }


    }



}
