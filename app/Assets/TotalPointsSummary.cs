using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalPointsSummary : MonoBehaviour
{

    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    // Start is called before the first frame update
    void Start()


    {

        Debug.Log(Game.worlds[0].total_pointsL1);


        s1.transform.localScale = new Vector3(1f, 2*Game.worlds[0].total_pointsL1 * 0.335f, 1f);
        s2.transform.localScale = new Vector3(1f, 2*Game.worlds[1].total_pointsL1 * 0.335f, 1f);
        s3.transform.localScale = new Vector3(1f, 2*Game.worlds[2].total_pointsL1 * 0.335f, 1f);
        Debug.Log(s1.transform.localScale);
    }

    void Update()
    {
        s1.transform.localScale = new Vector3(1f, 2 * Game.worlds[0].total_pointsL1 * 0.335f, 1f);
        s2.transform.localScale = new Vector3(1f, 2 * Game.worlds[1].total_pointsL1 * 0.335f, 1f);
        s3.transform.localScale = new Vector3(1f, 2 * Game.worlds[2].total_pointsL1 * 0.335f, 1f);        
    }


}
