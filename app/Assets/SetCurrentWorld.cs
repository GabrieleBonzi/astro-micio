using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCurrentWorld : MonoBehaviour
{

    public int ID;
    public void Set()
    {
        Game.SetCurrentWorldID(ID);
        Debug.Log(Game.currentWorld);

        
    }
}
