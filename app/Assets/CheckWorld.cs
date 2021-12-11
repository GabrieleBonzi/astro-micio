using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Debug.Log(Game.worlds[0].levels);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
