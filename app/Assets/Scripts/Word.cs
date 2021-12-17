using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType {
    HARD,
    SOFT,
    NONE
}

public class Word : MonoBehaviour
{
    [System.Serializable]
    public struct BaseObj
    {
        public string word;
        public GameObject text;
        public GameObject image;
        public AudioClip audio;
        public SoundType type;
    }

    public List<BaseObj> words = new List<BaseObj>();  
}
