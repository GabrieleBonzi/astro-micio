using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllAnimations : MonoBehaviour
{

    public GameObject diamond;
    public float points;
    public float token = 0;
    public bool destr = false;
    public float time = AddInBucket.timer;



    // Start is called before the first frame update
    void Awake()
    {
        points = SpawnerObjects.totalPoints;
        destr = AddInBucket.destroyed;
        time = AddInBucket.timer;
}

    // Update is called once per frame
    void Update() {

        time = AddInBucket.timer;
        points = SpawnerObjects.totalPoints;
        destr = AddInBucket.destroyed;

        if (token < points)
        {
            diamond.GetComponent<Animator>().enabled = true;
            token = points;

        }
        else if (token == points & destr == false) 
        {
                diamond.GetComponent<Animator>().enabled = false;
        }


    
        
    }
}
