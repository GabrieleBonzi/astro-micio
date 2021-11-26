using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBouncer : MonoBehaviour
{

    public GameObject bouncerActive;
    public GameObject bouncerNotActive;

    // Start is called before the first frame update
    public void Activebounc()
    {
        bouncerActive.SetActive(true);
        bouncerNotActive.SetActive(false);
    }

   
}
