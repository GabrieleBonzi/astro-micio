using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjects : MonoBehaviour
{

    //spawning mechanics
    public static Vector3 spawnPoint;
    public int timeTilNextSpawn = 5;
    float timer = 0;
    private GameObject obj;

    //accessing list 
    public GameObject spawnObject;
    public AudioSource audioSource;
    public List<Word.baseobj> WordsList;

    private GameObject Image;
    private AudioClip clip;
    public static  SoundType typeS;

    //points mechanics
    public static Vector3 choice = new Vector3(0,0,0);
    public List<Word.baseobj> WrongWords = new List<Word.baseobj>();
    public float BaseValue = 1f;
    public float totalPoints = 0f;
    public int i = 0;
    void Start()
    {
        timer = 0;
        spawnPoint = transform.position;
        WordsList = spawnObject.GetComponent<Word>().Words;
        Image = WordsList[0].image;
        clip = WordsList[0].audio;
        typeS = WordsList[0].type;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (obj == null)
        {
            if (choice != Vector3.zero) 
            {
                if (choice == spawnPoint)
                {
                    i--;
                }

                else
                {
                    var left = choice.x < spawnPoint.x;

                    switch (left, typeS)
                    {

                        case (true, SoundType.SOFT):
                            WrongWords.Add(WordsList[i - 1]);
                            break;
                        case (true, SoundType.HARD):
                            totalPoints += BaseValue;
                            break;
                        case (false, SoundType.SOFT):
                            totalPoints += BaseValue;
                            break;
                        case (false, SoundType.HARD):
                            WrongWords.Add(WordsList[i - 1]);
                            break;


                    }

                    choice =  Vector3.zero;
                    Debug.Log(WrongWords[0].word);
                }
            }

            if (i >= WordsList.Count)
            {

                WordsList = WrongWords;
                i = 0;
                WrongWords.Clear();
                BaseValue = 0.5f;
                //Debug.Log(BaseValue);
            }
            if (WordsList.Count == 0 && WrongWords.Count == 0) {
                Debug.Log("fine");
                return;
            
            }
            Spawn();
            i += 1;
            timer = 0;
        }
        else if (timer>=timeTilNextSpawn)
        {

            obj.GetComponent<Rigidbody2D>().gravityScale = 1;

        }

        
    }

    void Spawn()
    {
        
         
        
            obj = Instantiate(Image, spawnPoint, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().gravityScale = 0;
            audioSource.PlayOneShot(clip);
    
    }
}
