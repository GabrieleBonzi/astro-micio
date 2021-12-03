using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHelp : MonoBehaviour
{




    public GameObject questo;
    private int index;
    public List<GameObject> ValuesText = new List<GameObject>();
    public bool dialogue = false;
    private bool first_time = true;
    
    // Start is called before the first frame update
    void Awake()
    {
        dialogue = AddInBucket.dialogue;
    }

    // Update is called once per frame
    void Update()
    {

        dialogue = AddInBucket.dialogue;
        
        if (dialogue==true)
        {
            questo.SetActive(true);

            if (AddInBucket.corr == true && first_time)
            {
                Debug.Log(true);
                Debug.Log(AddInBucket.corr);
                index = Random.Range(0, 1);
                Debug.Log(index);
                first_time = false;
            }
            else if (AddInBucket.corr == false && first_time)
            {
                Debug.Log(false);
                index = Random.Range(2, 3);
                Debug.Log(AddInBucket.corr);
                Debug.Log(index);
                first_time = false;

            }

            ValuesText[index].transform.localScale = new Vector3(1f, 1f, 1f);

        }
        else if (dialogue== false)
        {
            questo.SetActive(false);
            ValuesText[index].transform.localScale = new Vector3(0, 0, 0);
            first_time = true;
        }




    }
}
