using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjectsTUTORIALWorld1 : MonoBehaviour
{

    // Spawn mechanics
    public static Vector3 spawnPoint;
    public uint waitingTime;
    private float timer;
    private GameObject obj;

    // Access wordList 
    public GameObject spawnObject;
    public AudioSource audioSource;
    public List<Word.BaseObj> wordList;
    public Word.BaseObj word;

    // Score mechanics
    public int item_index;
    public float baseValue;
    public float totalPoints;
    public static Vector3 choice = Vector3.zero;
    public List<Word.BaseObj> wrongWords = new List<Word.BaseObj>();
    public AudioSource CorrErr;
    public AudioClip corr;
    public AudioClip err;



    // tutorial mechanics 
    public GameObject controller;
    public GameObject background;
    public GameObject canvas;
    public GameObject tsR;
    public GameObject tsL;
    public GameObject button;
    public GameObject buttonR;
    public GameObject buttonL;
    public GameObject robot;
    private int counter=0;

    //audio
    public AudioSource speaker;
    public AudioClip audio1;
    public AudioClip audio3;
    public AudioClip audio4;
    public AudioClip audio5;

    

    private void Start()
    {
        // set environment
        timer = 0;
        waitingTime = 5; // 5 seconds
        item_index = 0;
        baseValue = 1f;
        totalPoints = 0f;
        spawnPoint = transform.position;

        // get wordlist
        wordList = spawnObject.GetComponent<Word>().words;
        UpdateWord();
        speaker.PlayOneShot(audio1);
    }

    private void SpawnObject()
    {
        if (item_index >= wordList.Count) return;

        if (counter == 2)
        {

        }
        else if (counter == 0)
        {
            counter += 1;
        }
        obj = Instantiate(word.image, spawnPoint, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().gravityScale = 0;
        audioSource.PlayOneShot(word.audio);

        timer = 0;
    }

    private void UpdateWord()
    {
        if (item_index < 0) return;
        if (wordList.Count <= 0) return;
        if (item_index >= wordList.Count)
        {

            Debug.Log("fine");
            speaker.Stop();
            speaker.PlayOneShot(audio5);
            controller.SetActive(true);
            background.SetActive(true);
            buttonL.SetActive(false);
            buttonR.SetActive(false);
            canvas.transform.GetChild(3).transform.localScale = new Vector3(0, 0, 0);
            canvas.transform.GetChild(5).transform.localScale = new Vector3(1.09090078f, 1.09090078f, 1.09090078f); ;
            canvas.SetActive(true);
            button.SetActive(true);
            robot.GetComponent<Animator>().enabled = true;


            return;
        }
        word = wordList[item_index];
    }

    private void UpdateWordList()
    {
        item_index = 0;
        baseValue = 0.5f;
        wordList.Clear();

        if (wrongWords.Count <= 0) return;

        wordList = new List<Word.BaseObj>(wrongWords);
        wrongWords.Clear();
        UpdateWord();
    }

    private void CorrectGuess()
    {
        totalPoints += baseValue;
        CorrErr.PlayOneShot(corr);
    }

    private void WrongGuess()
    {
        wrongWords.Add(word);

    }

    private void CheckChoice()
    {
        // null vector
        if (choice == Vector3.zero) return;
        // respawn same item
        if (choice == spawnPoint) return;

        // switch correct/wrong guess
        var isLeft = choice.x < spawnPoint.x;

        switch (isLeft, word.type)
        {
            case (true, SoundType.SOFT):
                WrongGuess();
                break;
            case (true, SoundType.HARD):
                CorrectGuess();
                break;
            case (false, SoundType.SOFT):
                CorrectGuess();
                break;
            case (false, SoundType.HARD):
                WrongGuess();
                break;
        }
        ++item_index;
        UpdateWord();
        choice = Vector3.zero;
    }


    private void checkTUTORIAL() {


        if (counter == 1)
        {
            controller.SetActive(true);
            background.SetActive(true);
            canvas.SetActive(true);
            button.SetActive(false);
            robot.GetComponent<Animator>().enabled = true;
            speaker.Stop();
            speaker.PlayOneShot(audio3);
            tsR.SetActive(true);
            buttonR.SetActive(false);
            buttonL.SetActive(true);
            ActiveBouncer.control = 1;
            counter = 0;

            

        }
        else if (counter == 2) 
        
        {


            controller.SetActive(true);
            background.SetActive(true);
            canvas.transform.GetChild(2).transform.localScale = new Vector3(0,0,0);
            canvas.transform.GetChild(3).transform.localScale = new Vector3(1.09090078f, 1.09090078f, 1.09090078f); ;
            canvas.SetActive(true);
            button.SetActive(false);
            robot.GetComponent<Animator>().enabled = true;
            speaker.Stop();
            speaker.PlayOneShot(audio4);
            tsL.SetActive(true);
            buttonR.SetActive(true);
            buttonL.SetActive(false);

            ActiveBouncer.control = 2;
            counter = 0;

        }

    }

    private void Update()
    {
        // check integrity of lists
        if (wordList.Count == 0) return;

        if (controller.activeInHierarchy == false)
        {
            // update timer
            timer += Time.deltaTime;
        }


        // initialize word spawning behavior
        if (obj == null && controller.activeInHierarchy==false)
        {
            CheckChoice();
            SpawnObject();

        }
        else if  (timer >= waitingTime / 2 +1 && controller.activeInHierarchy == false && counter !=0)
            {

            if (counter == 1 && ActiveBouncer.control == 1)
            {
                counter = 2;
            }
            Debug.Log("ecco");

                checkTUTORIAL();
            }
            
        else if (timer >= waitingTime && controller.activeInHierarchy == false) //&& Input.GetMouseButtonDown(0)
        {
            obj.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        if (item_index >= wordList.Count) UpdateWordList();
    }
}



