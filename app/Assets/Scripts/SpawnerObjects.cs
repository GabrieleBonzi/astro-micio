using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    // Score mechanics and its control
    public int item_index;
    public float baseValue;
    public static float totalPoints;
    public static Vector3 choice = Vector3.zero;
    public List<Word.BaseObj> wrongWords = new List<Word.BaseObj>();

    // End Level
    public Animator transition;

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
        if (item_index >= wordList.Count) { 
            Debug.Log("fine"); 
            return; }
        
        word = wordList[item_index];
    }

    private void UpdateWordList()
    {
        item_index = 0;
        baseValue = baseValue/2;
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

    IEnumerator LoadLevel(int levelIndex)
    {


        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(1);

        //Load acene
        SceneManager.LoadScene(levelIndex);

    }
    public void LoadNextLevel()
    {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

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



