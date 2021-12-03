using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour
{


    public Text scoreText;


    float CurrentScore;
    // Start is called before the first frame update
    void Start()
    {
        CurrentScore = SpawnerObjects.totalPoints;
        scoreText.text = CurrentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScore = SpawnerObjects.totalPoints;
        scoreText.text = CurrentScore.ToString();
    }
}
