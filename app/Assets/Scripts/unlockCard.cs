using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockCard : MonoBehaviour
{

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;

    public GameObject a1;
    public GameObject a2;
    public GameObject a3;





    // Start is called before the first frame update
    void Start()


    {
        if (Game.worlds[0].total_pointsL1 > 7) 
        {
            c1.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            a1.SetActive(false);
        }

        if (Game.worlds[1].total_pointsL1 > 7)
        {
            c2.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            a2.SetActive(false);
        }

        if (Game.worlds[2].total_pointsL1 > 7)
        {
            c3.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            a3.SetActive(false);
        }

    }

}
