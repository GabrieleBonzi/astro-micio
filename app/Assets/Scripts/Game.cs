using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Level
{
    public bool played;
    public bool passed;
    public float total_points;
    public Level()
    {
        passed = false;
        played = false;
        total_points = 0;
    }
}


public class World
{
    public string name;
    public bool visited;
    public int current_level;
    public int max_level;
    public bool completed;
    public bool friend;
    public bool playedL1;
    public bool passedL1;
    public float total_pointsL1;

    public World(int _max_level, Level _levels)
    {
        visited = false;
        current_level = 0;
        max_level = _max_level;
        completed = false;
        friend = false;
        passedL1 = false;
        playedL1 = false;
        total_pointsL1 = 0;
    }

    private void UpdateCompleted()
    {
        completed = true;

       if (!passedL1) { completed = false; }

    }

    public bool Completed()
    {
        UpdateCompleted();
        return completed;
    }
}

public class Game : MonoBehaviour
{
    static public List<World> worlds;
    static private string save_filename;
    static private string config_filename;
    static public string[] world_names;
    static public int currentWorld=0;


    public Game()
    {
        save_filename = "SaveGame.json";
        config_filename = "Config.json";
        world_names = new string[] { "FirstWorld", "SecondWorld", "ThirdWorld" };
        worlds = new List<World> { };
    }

    public void Awake()
    {
        
        
        LoadOrStartGame();
        

    }


    public static void LoadGameConfig(string filename)
    {
        
            var jsonString = System.IO.File.ReadAllText(Application.dataPath + "/Saves/" + filename + ".json");
            worlds.Add(JsonUtility.FromJson<World>(jsonString));


        
    }

    public static void LoadGameInfo(string filename)
    {
        
            var jsonString = System.IO.File.ReadAllText(Application.dataPath + "/Saves/" + filename + "_1.json");
            worlds.Add(JsonUtility.FromJson<World>(jsonString));
        
    }

    public static void SaveGameInfo()
    {
        //foreach (var world in worlds)
        //{
        string game_data_string = JsonUtility.ToJson(worlds[currentWorld]);
        Debug.Log(worlds[currentWorld]);
        Debug.Log(game_data_string);
        Debug.Log(worlds[currentWorld].playedL1);
        System.IO.File.WriteAllText(Application.dataPath + "/Saves/" + worlds[currentWorld].name + "_1.json", game_data_string);
        //}
    }

    public static void LoadOrStartGame() 
    {

        foreach (var filename in world_names)
        {
            if (System.IO.File.Exists(Application.dataPath + "/Saves/" + filename + "_1.json"))
            {
                LoadGameInfo(filename);
            }
            else
            {
                LoadGameConfig(filename);
            }
        }
    }



    public static void CompleatedLevel( float points) 
    {

        if (points >= 4)
        {
            worlds[currentWorld].passedL1 = true;
        }
        worlds[currentWorld].total_pointsL1 = points;
        worlds[currentWorld].Completed();
        
    }

    public static void CollectFriend() 
    {
        worlds[currentWorld].friend = true;

            Debug.Log('d');


    }

    public static void PlayedLevel()

    {
        


        worlds[currentWorld].playedL1 = true;


    }

    public static void SetCurrentWorldID(int i)
    {
        currentWorld = i;
        
    }
}