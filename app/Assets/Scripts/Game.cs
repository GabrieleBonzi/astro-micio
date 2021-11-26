using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Game : MonoBehaviour
//{
//    public List<Word> words { get; }
//    public int level { get; set; }

//    private void Awake()
//    {
//        this.loadWords();
//    }


//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    // parse .csv with all words
//    private void loadWords()
//    {
//        var dataset = Resources.Load<TextAsset>("words.csv");
//        Debug.Log(dataset);
//        var dataLines = dataset.text.Split('\n');

//        for (int i = 1; i < dataLines.Length; i++) // start from 1 to skip title
//        {
//            var data = dataLines[i].Split(',');
//            if (data[1] == "1")
//            {
//                this.words.Add(new Word(data[3]));
//            }
//        }
//    }
//}
