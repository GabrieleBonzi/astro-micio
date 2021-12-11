using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHelp : MonoBehaviour
{




    public GameObject questo;
    public GameObject robot;
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

            if (SpawnerObjects.correct == true && first_time)
            {
                //Debug.Log(true);
                //Debug.Log(SpawnerObjects.correct);
                index = Random.Range(0, 2);
                //Debug.Log(index);
                first_time = false;
            }
            else if (SpawnerObjects.correct == false && first_time)
            {
                //Debug.Log(false);
                index = Random.Range(2, 4);
                //Debug.Log(SpawnerObjects.correct);
                //Debug.Log(index);
                first_time = false;

            }
            robot.GetComponent<Animator>().enabled = true;
            ValuesText[index].transform.localScale = new Vector3(1f, 1f, 1f);

        }
        else if (dialogue== false)
        {
            questo.SetActive(false);
            ValuesText[index].transform.localScale = new Vector3(0, 0, 0);
            robot.GetComponent<Animator>().enabled = false;
            first_time = true;
        }




    }
}
