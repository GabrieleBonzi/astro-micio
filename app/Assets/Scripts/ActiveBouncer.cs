using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBouncer : MonoBehaviour
{

    public GameObject bouncerActive;
    public GameObject bouncerNotActive;



    //tutorial 
    public static int control = 0;
    public GameObject controller;
    public GameObject background;
    public GameObject canvas;
    public GameObject tsR;
    public GameObject tsL;
    public GameObject robot;

    // Start is called before the first frame update
    public void Activebounc()
    {
        bouncerActive.SetActive(true);
        bouncerNotActive.SetActive(false);

        if (controller != null && controller.activeInHierarchy && control == 1)
        {


            controller.SetActive(false);
            background.SetActive(false);
            canvas.SetActive(false);
            robot.GetComponent<Animator>().enabled = false;
            tsR.SetActive(false);

        }
        else if (controller != null && controller.activeInHierarchy && control == 2) {
            controller.SetActive(false);
            background.SetActive(false);
            canvas.SetActive(false);
            robot.GetComponent<Animator>().enabled = false;
            tsL.SetActive(false);
            NextTextTUTORIAL.numberClicks = 3;
        }
    }

   
}
