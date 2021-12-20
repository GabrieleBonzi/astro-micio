using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnerObjects : MonoBehaviour
{

    // Spawn mechanics
    public static Vector3 spawnPoint;
    public uint waitingTime;
    private float timer;
    private GameObject obj;
    private bool firstobj;

    // Access wordList 
    public GameObject spawnObject;
    public AudioSource audioSource;
    public List<Word.BaseObj> wordList;
    public Word.BaseObj word;

    // timer
    public GameObject timebar;


    // Score mechanics and its control
    public int item_index;
    public float baseValue;
    public static float totalPoints;
    public static Vector3 choice = Vector3.zero;
    public List<Word.BaseObj> wrongWords = new List<Word.BaseObj>();
    public static bool correct;
    public AudioSource CorrErr;
    public AudioClip corr;
    public AudioClip err;
    public AudioClip end;
    //errors
    public float[] w;
    public string nameWord;
    //corrects
    public float[] correctW;


    // End Level
    public Animator transition;
    public static bool passed = false;
    public GameObject CongratulationsMenuUI;
    public GameObject cartapresa;
    public GameObject cartanonpresa;


    //diamonds
    public GameObject diamond_5;
    public GameObject diamond_6;
    public GameObject diamond_7;
    public GameObject diamond_8;
    public GameObject diamond_9;
    public GameObject diamond_10;
    private Color tmp;




    private void Start()
    {
        // set environment
        timer = 0;
        waitingTime = 5; // 5 seconds
        item_index = 0;
        baseValue = 1f;
        totalPoints = 0f;
        spawnPoint = transform.position;
        firstobj = true;
        passed = false;
        w = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        correctW = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        // get wordlist
        wordList = spawnObject.GetComponent<Word>().words;
        UpdateWord();
        Game.PlayedLevel();
    }

    private void SpawnObject()
    {
        if (item_index >= wordList.Count) 
        {
            //Debug.Log('y');
            return; 
        }
        timebar.GetComponent<Animator>().enabled = true;
        //timebar.GetComponent<Animator>().Play("time_bar");
        obj = Instantiate(word.image, spawnPoint, Quaternion.identity);
        nameWord = word.word;
        obj.GetComponent<Rigidbody2D>().gravityScale = 0;
        audioSource.PlayOneShot(word.audio);


        timer = 0;
    }

    private void UpdateWord()
    {
        if (item_index < 0) return;
        if (wordList.Count <= 0) return;
        if (item_index >= wordList.Count) {
            return; }
        
        word = wordList[item_index];
    }

    private void UpdateWordList()
    {
        item_index = 0;
        baseValue = 0.5f;
        wordList.Clear();

        if (wrongWords.Count <= 0) {

            //END GAME--------
            audioSource.PlayOneShot(end);
            passed = true;
            Game.CompleatedLevel(totalPoints,w,correctW);
            Game.SaveGameInfo();
            Game.SaveGameInfoError();
            CongratulationsMenuUI.SetActive(true);
            diamondsDisplay(totalPoints);
            Time.timeScale = 0f; //freeze the game
            return; }

        wordList = new List<Word.BaseObj>(wrongWords);
        wrongWords.Clear();
        UpdateWord();
    }

    private void CorrectGuess()
    {
        correct = true;
        totalPoints += baseValue;
        CorrErr.PlayOneShot(corr);

        //Debugga usando name per capire cosa viene stampato perchè per ora non viene aggiornato il valore
        // tenendo traccia di anche le risposte giuste 
        if (nameWord == "Cane" | nameWord == "Gallina" | nameWord == "Scacchiera")
        {
            correctW[0] = correctW[0] + 1;
        }
        else if (nameWord == "Cappello" | nameWord == "Gambero" | nameWord == "Scarpa")
        {
            correctW[1] = correctW[1] + 1;
        }
        else if (nameWord == "Cervello" | nameWord == "Gelato" | nameWord == "Sceriffo")
        {
            correctW[2] = correctW[2] + 1;
        }
        else if (nameWord == "Cigno" | nameWord == "Gemelli" | nameWord == "Scheletro")
        {
            correctW[3] = correctW[3] + 1;
        }
        else if (nameWord == "Cinghiale" | nameWord == "Gengiva" | nameWord == "Schiuma")
        {
            correctW[4] = correctW[4] + 1;
        }
        else if (nameWord == "Cipolla" | nameWord == "Ghiacciolo" | nameWord == "Scimmia")
        {
            correctW[5] = correctW[5] + 1;
        }
        else if (nameWord == "Coccodrillo" | nameWord == "Gigante" | nameWord == "Scoiattolo")
        {
            correctW[6] = correctW[6] + 1;
        }
        else if (nameWord == "Coda" | nameWord == "Giraffa" | nameWord == "Scopa")
        {
            correctW[7] = correctW[7] + 1;
        }
        else if (nameWord == "Cozza" | nameWord == "Guanto" | nameWord == "Scorpione")
        {
            correctW[8] = correctW[8] + 1;
        }
        else if (nameWord == "Cuore" | nameWord == "Ghiande" | nameWord == "Scudo")
        {
            correctW[9] = correctW[9] + 1;
        }
    }

    private void WrongGuess()
    {
        correct = false;
        wrongWords.Add(word);
        CorrErr.PlayOneShot(err);

        
        //collecting wrong guesses NOTA -->(1-err/tot)*100
        
        if (nameWord == "Cane" | nameWord == "Gallina" | nameWord == "Scacchiera")
        {
            w[0] = w[0] + 1;
        }
        else if (nameWord == "Cappello" | nameWord == "Gambero" | nameWord == "Scarpa") 
        {
            w[1] = w[1] + 1;
        }
        else if (nameWord == "Cervello" | nameWord == "Gelato" | nameWord == "Sceriffo")
        {
            w[2] = w[2] + 1;
        }
        else if (nameWord == "Cigno" | nameWord == "Gemelli" | nameWord == "Scheletro")
        {
            w[3] = w[3] + 1;
        }
        else if (nameWord == "Cinghiale" | nameWord == "Gengiva" | nameWord == "Schiuma")
        {
            w[4] = w[4] + 1;
        }
        else if (nameWord == "Cipolla" | nameWord == "Ghiacciolo" | nameWord == "Scimmia")
        {
            w[5] = w[5] + 1;
        }
        else if (nameWord == "Coccodrillo" | nameWord == "Gigante" | nameWord == "Scoiattolo")
        {
            w[6] = w[6] + 1;
        }
        else if (nameWord == "Coda" | nameWord == "Giraffa" | nameWord == "Scopa")
        {
            w[7] = w[7] + 1;
        }
        else if (nameWord == "Cozza" | nameWord == "Guanto" | nameWord == "Scorpione")
        {
            w[8] = w[8] + 1;
        }
        else if (nameWord == "Cuore" | nameWord == "Ghiande" | name == "Scudo")
        {
            w[9] = w[9] + 1;
        }


    }

    public void CheckChoice()
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
        //correct = true;
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


    private void diamondsDisplay(float points) 
    {

        if (points >= 4.5f & points <= 5.0f)
        {
            //diamond 5
            tmp = diamond_5.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_5.GetComponent<SpriteRenderer>().color = tmp;
            cartanonpresa.SetActive(true);
        }
        else if (points >= 5.5f & points <= 6.0f)
        {
            //diamond 5
            tmp = diamond_5.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_5.GetComponent<SpriteRenderer>().color = tmp;

            //diamond 6
            tmp = diamond_6.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_6.GetComponent<SpriteRenderer>().color = tmp;
            cartanonpresa.SetActive(true);
        }
        else if (points >= 6.5f & points <= 7.0f)
        {
            //diamond 5
            tmp = diamond_5.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_5.GetComponent<SpriteRenderer>().color = tmp;

            //diamond 6
            tmp = diamond_6.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_6.GetComponent<SpriteRenderer>().color = tmp;

            //diamond 7
            tmp = diamond_7.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_7.GetComponent<SpriteRenderer>().color = tmp;

            cartapresa.SetActive(true);
        }
        else if (points >= 7.5f & points <= 8.0f)
        {
            //diamond 5
            tmp = diamond_5.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_5.GetComponent<SpriteRenderer>().color = tmp;

            //diamond 6
            tmp = diamond_6.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_6.GetComponent<SpriteRenderer>().color = tmp;

            //diamond 7
            tmp = diamond_7.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_7.GetComponent<SpriteRenderer>().color = tmp;

            //diamond 8
            tmp = diamond_8.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_8.GetComponent<SpriteRenderer>().color = tmp;
            cartapresa.SetActive(true);
        }
        else if (points >= 8.5f & points <= 9.0f)
        {
            //diamond 5
            tmp = diamond_5.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_5.GetComponent<SpriteRenderer>().color = tmp;

            //diamond 6
            tmp = diamond_6.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_6.GetComponent<SpriteRenderer>().color = tmp;

            //diamond 7
            tmp = diamond_7.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_7.GetComponent<SpriteRenderer>().color = tmp;

            //diamond 8
            tmp = diamond_8.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_8.GetComponent<SpriteRenderer>().color = tmp;

            //diamond 9
            tmp = diamond_9.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_9.GetComponent<SpriteRenderer>().color = tmp;
            cartapresa.SetActive(true);
        }

        else if (points >= 9.5f & points <= 10f)
        {
            //diamond 5
            tmp = diamond_5.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_5.GetComponent<SpriteRenderer>().color = tmp;

            //diamond 6
            tmp = diamond_6.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_6.GetComponent<SpriteRenderer>().color = tmp;

            //diamond 7
            tmp = diamond_7.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_7.GetComponent<SpriteRenderer>().color = tmp;

            //diamond 8
            tmp = diamond_8.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_8.GetComponent<SpriteRenderer>().color = tmp;

            //diamond 9
            tmp = diamond_9.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_9.GetComponent<SpriteRenderer>().color = tmp;

            //diamond 10
            tmp = diamond_10.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            diamond_10.GetComponent<SpriteRenderer>().color = tmp;
            cartapresa.SetActive(true);
        }
       
    }


    private void Update()
    {
        


        if (passed == true)return;
        // check integrity of lists
        if (wordList.Count == 0) return;

        
        

        // update timer
        timer += Time.deltaTime;

        // initialize word spawning behavior
        if (obj == null)
        {
            if (firstobj)
            {
                SpawnObject();
                firstobj = false;
            }
            else
            {
                CheckChoice();
                SpawnObject();
            }
        }
        else if (timer >= waitingTime)
        {
            timebar.GetComponent<Animator>().enabled = false;
            obj.GetComponent<Rigidbody2D>().gravityScale = 1;
            
            timebar.transform.localScale = new Vector3(1, 1, 1);
        }
        if (item_index >= wordList.Count) UpdateWordList();
    }
}



