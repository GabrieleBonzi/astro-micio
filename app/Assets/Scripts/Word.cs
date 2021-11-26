using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum SoundType { 

        SOFT,
        HARD,
        NONE


}
public class Word : MonoBehaviour
{


    [System.Serializable]
    public struct baseobj
    {


        public GameObject image;
        public string word;
        public AudioClip audio;
        public SoundType type;
    }

    public List<baseobj> Words = new List<baseobj>();

 


    
    
}
