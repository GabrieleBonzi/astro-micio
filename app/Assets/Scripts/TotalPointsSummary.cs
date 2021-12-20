using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalPointsSummary : MonoBehaviour
{

    public GameObject s1;
    public GameObject s2;
    public GameObject s3;



    public Text p1;
    public Text p2;
    public Text p3;


    //livello 1 mondo 1
    public Text[] e1;

    //livello 1 mondo 2
    public Text[] e2;

    //livello 1 mondo 3
    public Text[] e3;


    public GameObject l1;
    public GameObject l2;
    public GameObject l3;


    public GameObject lu1;
    public GameObject lu2;
    public GameObject lu3;



    // Start is called before the first frame update
    void Start()


    {

        s1.transform.localScale = new Vector3(1f, 2*Game.worlds[0].total_pointsL1 * 0.335f, 1f);
        s2.transform.localScale = new Vector3(1f, 2*Game.worlds[1].total_pointsL1 * 0.335f, 1f);
        s3.transform.localScale = new Vector3(1f, 2*Game.worlds[2].total_pointsL1 * 0.335f, 1f);

        var CurrentScore = Game.worlds[0].total_pointsL1;
        p1.text = CurrentScore.ToString();
        var CurrentScore1 = Game.worlds[1].total_pointsL1;
        p2.text = CurrentScore1.ToString();
        var CurrentScore2 = Game.worlds[2].total_pointsL1;
        p3.text = CurrentScore2.ToString();

        UpdateText();


        if(Game.errors[0].w1 != 0) 
        {
            l1.SetActive(true);
            lu1.SetActive(false);
        }
        if (Game.errors[1].w1 != 0)
        {
            l2.SetActive(true);
            lu2.SetActive(false);
        }

        if (Game.errors[2].w1 != 0)
        {
            l3.SetActive(true);
            lu3.SetActive(false);
        }



    }


    public void UpdateText() 
    {
        if (Game.errors[0].w1_new != 0)
        {


            e1[0].text = Game.errors[0].w1_new.ToString();
            e1[1].text = Game.errors[0].w2_new.ToString();
            e1[2].text = Game.errors[0].w3_new.ToString();
            e1[3].text = Game.errors[0].w4_new.ToString();
            e1[4].text = Game.errors[0].w5_new.ToString();
            e1[5].text = Game.errors[0].w6_new.ToString();
            e1[6].text = Game.errors[0].w7_new.ToString();
            e1[7].text = Game.errors[0].w8_new.ToString();
            e1[8].text = Game.errors[0].w9_new.ToString();
            e1[9].text = Game.errors[0].w10_new.ToString();


//----------------------------------------------------------

            if (Game.errors[0].w1_new > Game.errors[0].w1)
            {
                e1[0].color = Color.red;
            }
            else if (Game.errors[0].w1_new < Game.errors[0].w1)
            {
                e1[0].color = Color.green;
            }



            if (Game.errors[0].w2_new > Game.errors[0].w2)
            {
                e1[1].color = Color.red;
            }
            else if (Game.errors[0].w2_new < Game.errors[0].w2)
            {
                e1[1].color = Color.green;
            }



            if (Game.errors[0].w3_new > Game.errors[0].w3)
            {
                e1[2].color = Color.red;
            }
            else if (Game.errors[0].w3_new < Game.errors[0].w3)
            {
                e1[2].color = Color.green;
            }



            if (Game.errors[0].w4_new > Game.errors[0].w4)
            {
                e1[3].color = Color.red;
            }
            else if (Game.errors[0].w4_new < Game.errors[0].w4)
            {
                e1[3].color = Color.green;
            }



            if (Game.errors[0].w5_new > Game.errors[0].w5)
            {
                e1[4].color = Color.red;
            }
            else if (Game.errors[0].w5_new < Game.errors[0].w5)
            {
                e1[4].color = Color.green;
            }


            if (Game.errors[0].w6_new > Game.errors[0].w6)
            {
                e1[5].color = Color.red;
            }
            else if (Game.errors[0].w2_new < Game.errors[0].w2)
            {
                e1[5].color = Color.green;
            }


            if (Game.errors[0].w7_new > Game.errors[0].w7)
            {
                e1[6].color = Color.red;
            }
            else if (Game.errors[0].w7_new < Game.errors[0].w7)
            {
                e1[6].color = Color.green;
            }


            if (Game.errors[0].w8_new > Game.errors[0].w8)
            {
                e1[7].color = Color.red;
            }
            else if (Game.errors[0].w8_new < Game.errors[0].w8)
            {
                e1[7].color = Color.green;
            }


            if (Game.errors[0].w9_new > Game.errors[0].w9)
            {
                e1[8].color = Color.red;
            }
            else if (Game.errors[0].w9_new < Game.errors[0].w9)
            {
                e1[8].color = Color.green;
            }


            if (Game.errors[0].w10_new > Game.errors[0].w10)
            {
                e1[9].color = Color.red;
            }
            else if (Game.errors[0].w10_new < Game.errors[0].w10)
            {
                e1[9].color = Color.green;
            }
            //----------------------------------------------------------


        }
        else if (Game.errors[0].w1_new == 0)
        {
            e1[0].text = Game.errors[0].w1.ToString();
            e1[1].text = Game.errors[0].w2.ToString();
            e1[2].text = Game.errors[0].w3.ToString();
            e1[3].text = Game.errors[0].w4.ToString();
            e1[4].text = Game.errors[0].w5.ToString();
            e1[5].text = Game.errors[0].w6.ToString();
            e1[6].text = Game.errors[0].w7.ToString();
            e1[7].text = Game.errors[0].w8.ToString();
            e1[8].text = Game.errors[0].w9.ToString();
            e1[9].text = Game.errors[0].w10.ToString();
        }



        if (Game.errors[1].w1_new != 0)
        {


            e2[0].text = Game.errors[1].w1_new.ToString();
            e2[1].text = Game.errors[1].w2_new.ToString();
            e2[2].text = Game.errors[1].w3_new.ToString();
            e2[3].text = Game.errors[1].w4_new.ToString();
            e2[4].text = Game.errors[1].w5_new.ToString();
            e2[5].text = Game.errors[1].w6_new.ToString();
            e2[6].text = Game.errors[1].w7_new.ToString();
            e2[7].text = Game.errors[1].w8_new.ToString();
            e2[8].text = Game.errors[1].w9_new.ToString();
            e2[9].text = Game.errors[1].w10_new.ToString();


            //---------------------

            if (Game.errors[1].w1_new > Game.errors[1].w1)
            {
                e2[0].color = Color.red;
            }
            else if (Game.errors[1].w1_new < Game.errors[1].w1)
            {
                e2[0].color = Color.green;
            }



            if (Game.errors[1].w2_new > Game.errors[1].w2)
            {
                e2[1].color = Color.red;
            }
            else if (Game.errors[1].w2_new < Game.errors[1].w2)
            {
                e2[1].color = Color.green;
            }



            if (Game.errors[1].w3_new > Game.errors[1].w3)
            {
                e2[2].color = Color.red;
            }
            else if (Game.errors[1].w3_new < Game.errors[1].w3)
            {
                e2[2].color = Color.green;
            }



            if (Game.errors[1].w4_new > Game.errors[1].w4)
            {
                e2[3].color = Color.red;
            }
            else if (Game.errors[1].w4_new < Game.errors[1].w4)
            {
                e2[3].color = Color.green;
            }



            if (Game.errors[1].w5_new > Game.errors[1].w5)
            {
                e2[4].color = Color.red;
            }
            else if (Game.errors[1].w5_new < Game.errors[1].w5)
            {
                e2[4].color = Color.green;
            }


            if (Game.errors[1].w6_new > Game.errors[1].w6)
            {
                e2[5].color = Color.red;
            }
            else if (Game.errors[1].w2_new < Game.errors[1].w2)
            {
                e2[5].color = Color.green;
            }


            if (Game.errors[1].w7_new > Game.errors[1].w7)
            {
                e2[6].color = Color.red;
            }
            else if (Game.errors[1].w7_new < Game.errors[1].w7)
            {
                e2[6].color = Color.green;
            }


            if (Game.errors[1].w8_new > Game.errors[1].w8)
            {
                e2[7].color = Color.red;
            }
            else if (Game.errors[1].w8_new < Game.errors[1].w8)
            {
                e2[7].color = Color.green;
            }


            if (Game.errors[1].w9_new > Game.errors[1].w9)
            {
                e2[8].color = Color.red;
            }
            else if (Game.errors[1].w9_new < Game.errors[1].w9)
            {
                e2[8].color = Color.green;
            }


            if (Game.errors[1].w10_new > Game.errors[1].w10)
            {
                e2[9].color = Color.red;
            }
            else if (Game.errors[1].w10_new < Game.errors[1].w10)
            {
                e2[9].color = Color.green;
            }

            //---------------------
        }
        else if (Game.errors[1].w1_new == 0)
        {
            e2[0].text = Game.errors[1].w1.ToString();
            e2[1].text = Game.errors[1].w2.ToString();
            e2[2].text = Game.errors[1].w3.ToString();
            e2[3].text = Game.errors[1].w4.ToString();
            e2[4].text = Game.errors[1].w5.ToString();
            e2[5].text = Game.errors[1].w6.ToString();
            e2[6].text = Game.errors[1].w7.ToString();
            e2[7].text = Game.errors[1].w8.ToString();
            e2[8].text = Game.errors[1].w9.ToString();
            e2[9].text = Game.errors[1].w10.ToString();
        }


        if (Game.errors[2].w1_new != 0)
        {


            e3[0].text = Game.errors[2].w1_new.ToString();
            e3[1].text = Game.errors[2].w2_new.ToString();
            e3[2].text = Game.errors[2].w3_new.ToString();
            e3[3].text = Game.errors[2].w4_new.ToString();
            e3[4].text = Game.errors[2].w5_new.ToString();
            e3[5].text = Game.errors[2].w6_new.ToString();
            e3[6].text = Game.errors[2].w7_new.ToString();
            e3[7].text = Game.errors[2].w8_new.ToString();
            e3[8].text = Game.errors[2].w9_new.ToString();
            e3[9].text = Game.errors[2].w10_new.ToString();

            //-------------------------------

            if (Game.errors[2].w1_new > Game.errors[2].w1)
            {
                e3[0].color = Color.red;
            }
            else if (Game.errors[2].w1_new < Game.errors[2].w1)
            {
                e3[0].color = Color.green;
            }



            if (Game.errors[2].w2_new > Game.errors[2].w2)
            {
                e3[1].color = Color.red;
            }
            else if (Game.errors[2].w2_new < Game.errors[2].w2)
            {
                e3[1].color = Color.green;
            }



            if (Game.errors[2].w3_new > Game.errors[2].w3)
            {
                e3[2].color = Color.red;
            }
            else if (Game.errors[2].w3_new < Game.errors[2].w3)
            {
                e3[2].color = Color.green;
            }



            if (Game.errors[2].w4_new > Game.errors[2].w4)
            {
                e3[3].color = Color.red;
            }
            else if (Game.errors[2].w4_new < Game.errors[2].w4)
            {
                e3[3].color = Color.green;
            }



            if (Game.errors[2].w5_new > Game.errors[2].w5)
            {
                e3[4].color = Color.red;
            }
            else if (Game.errors[2].w5_new < Game.errors[2].w5)
            {
                e3[4].color = Color.green;
            }


            if (Game.errors[2].w6_new > Game.errors[2].w6)
            {
                e3[5].color = Color.red;
            }
            else if (Game.errors[2].w2_new < Game.errors[2].w2)
            {
                e3[5].color = Color.green;
            }


            if (Game.errors[2].w7_new > Game.errors[2].w7)
            {
                e3[6].color = Color.red;
            }
            else if (Game.errors[2].w7_new < Game.errors[2].w7)
            {
                e3[6].color = Color.green;
            }


            if (Game.errors[2].w8_new > Game.errors[2].w8)
            {
                e3[7].color = Color.red;
            }
            else if (Game.errors[2].w8_new < Game.errors[2].w8)
            {
                e3[7].color = Color.green;
            }


            if (Game.errors[2].w9_new > Game.errors[2].w9)
            {
                e3[8].color = Color.red;
            }
            else if (Game.errors[2].w9_new < Game.errors[2].w9)
            {
                e3[8].color = Color.green;
            }


            if (Game.errors[2].w10_new > Game.errors[2].w10)
            {
                e3[9].color = Color.red;
            }
            else if (Game.errors[2].w10_new < Game.errors[2].w10)
            {
                e3[9].color = Color.green;
            }

            //-------------------------------
        }
        else if (Game.errors[2].w1_new == 0)
        {
            e3[0].text = Game.errors[2].w1.ToString();
            e3[1].text = Game.errors[2].w2.ToString();
            e3[2].text = Game.errors[2].w3.ToString();
            e3[3].text = Game.errors[2].w4.ToString();
            e3[4].text = Game.errors[2].w5.ToString();
            e3[5].text = Game.errors[2].w6.ToString();
            e3[6].text = Game.errors[2].w7.ToString();
            e3[7].text = Game.errors[2].w8.ToString();
            e3[8].text = Game.errors[2].w9.ToString();
            e3[9].text = Game.errors[2].w10.ToString();
        }
    }

    void Update()
    {
        
    }


}
