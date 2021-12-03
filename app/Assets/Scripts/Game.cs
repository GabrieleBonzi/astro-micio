using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public bool played;
    public bool passed;
    public float total_points;

    public Level()
    {
        passed = true;
        played = true;
        total_points = 0;
    }
}


public class World
{
    public string name;
    public bool visited;
    public int current_level;
    public int max_level;
    private bool completed;
    public Level[] levels;

    public World(int _max_level, Level[] _levels)
    {
        visited = false;
        current_level = 0;
        max_level = _max_level;
        completed = false;
        levels = _levels;
    }

    private void UpdateCompleted()
    {
        completed = true;
        foreach (var level in levels)
        {
            if(!level.passed){ completed = false; }
        }
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
    static private string[] world_names;

    public Game()
    {
        save_filename = "SaveGame.json";
        config_filename = "Config.json";
        world_names = new string[] { "FirstWorld", "SecondWorld", "ThirdWorld"};
        worlds = new List<World> { };
    }

    public void Start()
    {
        LoadGameConfig();
        SaveGameInfo();
    }

    public void LoadGameConfig()
    {
        foreach (var filename in world_names)
        {
            var jsonString = System.IO.File.ReadAllText(Application.dataPath + "/Saves/" + filename + ".json");
            worlds.Add(JsonUtility.FromJson<World>(jsonString));
        }
    }

    public void LoadGameInfo()
    {
        foreach (var filename in world_names)
        {
            var jsonString = System.IO.File.ReadAllText(Application.dataPath + "/Saves/" + filename + "_1.json");
            worlds.Add(JsonUtility.FromJson<World>(jsonString));
        }
    }

    public void SaveGameInfo()
    {
        foreach (var world in worlds)
        {
            string game_data_string = JsonUtility.ToJson(world);
            System.IO.File.WriteAllText(Application.dataPath + "/Saves/" + world.name + "_1.json", game_data_string);
        }
    }
}