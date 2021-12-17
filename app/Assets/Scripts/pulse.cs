using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulse : MonoBehaviour
{

    public AnimationCurve expand;
    public float expamount;
    public float expspeed;

    Vector3 m_startSzie;
    Vector3 m_targetSzie;
    float scrollamount;

    void initpulse()
    {

        m_startSzie = transform.localScale;
        m_targetSzie = m_startSzie * expamount;

    }

    void makeFoodPulse()
    {

        scrollamount += Time.deltaTime * expspeed;
        float perc = expand.Evaluate(scrollamount);
        transform.localScale = Vector2.Lerp(m_startSzie, m_targetSzie, perc);


    }
    // Start is called before the first frame update
    void Start()
    {
        initpulse();
    }

    // Update is called once per frame
    void Update()
    {
        makeFoodPulse();
    }
}