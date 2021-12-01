using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjects : MonoBehaviour
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
    }

    private void SpawnObject()
    {
        if (item_index >= wordList.Count) return;

        obj = Instantiate(word.image, spawnPoint, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().gravityScale = 0;
        audioSource.PlayOneShot(word.audio);

        timer = 0;
    }

    private void UpdateWord()
    {
        if (item_index < 0) return;
        if (wordList.Count <= 0) return;
        if (item_index >= wordList.Count) return;
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

    private void Update()
    {
        // check integrity of lists
        if (wordList.Count == 0) return;
        

        // update timer
        timer += Time.deltaTime;

        // initialize word spawning behavior
        if (obj == null)
        {
            CheckChoice();
            SpawnObject();
        }
        else if (timer >= waitingTime)
        {
            obj.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        if (item_index >= wordList.Count) UpdateWordList();
    }
}



