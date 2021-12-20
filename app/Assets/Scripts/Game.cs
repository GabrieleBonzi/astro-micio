using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;







//contina con la configurazione del salvataggio degli errori alla riga 209. Ricorda che devi passare un vettore di numeri in spwawnObj per poi salvare su new solo dalla seconda volta che giocano in poi 
//1) carico il jason normale dove tutto e a zero
//2) carico il jason _1 aggiornando la prima riga quando il livello viene usato la prima volta 
//3) carico il jason _1 aggiornando la seconda riga qusndo il livello viene fatto dalla seconda volta in poi 
// capire come caricare gli errori visto che la posizione in lista cambia 



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


//-----------------------------------
public class saveErrors 
{
    public string name;

    public bool firstTime;
    

    public float w1;
    public float w2;
    public float w3;
    public float w4;
    public float w5;
    public float w6;
    public float w7;
    public float w8;
    public float w9;
    public float w10;

    public float w1_new;
    public float w2_new;
    public float w3_new;
    public float w4_new;
    public float w5_new;
    public float w6_new;
    public float w7_new;
    public float w8_new;
    public float w9_new;
    public float w10_new;


    public saveErrors( )
    {
        firstTime = false;

        w1 = 0;
        w2 = 0;
        w3 = 0;
        w4 = 0;
        w5 = 0;
        w6 = 0;
        w7 = 0;
        w8 = 0;
        w9 = 0;
        w10 = 0;




        w1_new = 0;
        w2_new = 0;
        w3_new = 0;
        w4_new = 0;
        w5_new = 0;
        w6_new = 0;
        w7_new = 0;
        w8_new = 0;
        w9_new = 0;
        w10_new = 0;



    }

}
//--------------------------------------------------------------------
public class Game : MonoBehaviour
{
    static public List<World> worlds;
    static public List<saveErrors> errors;
    //static private string save_filename;
    //static private string config_filename;
    static public string[] world_names;
    static public string[] error_names;
    static public int currentWorld;


    public Game()
    {
        //save_filename = "SaveGame.json";
        //config_filename = "Config.json";
        world_names = new string[] { "FirstWorld", "SecondWorld", "ThirdWorld" };
        error_names = new string[] { "Errors_world1_Lv1", "Errors_world2_Lv1", "Errors_world3_Lv1" };
        worlds = new List<World> { };
        errors = new List<saveErrors> { };
    }

    public void Awake()
    {

        
        LoadOrStartGame();
        LoadOrStartGameErrors();




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
  
        string game_data_string = JsonUtility.ToJson(worlds[currentWorld]);
        //Debug.Log(worlds[currentWorld]);
        //Debug.Log(game_data_string);
        //Debug.Log(worlds[currentWorld].playedL1);
        System.IO.File.WriteAllText(Application.dataPath + "/Saves/" + worlds[currentWorld].name + "_1.json", game_data_string);
  
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

    //--------------------------------------------------
    public static void LoadGameConfigError(string filename)
    {

        var jsonString = System.IO.File.ReadAllText(Application.dataPath + "/Saves/" + filename + ".json");
        errors.Add(JsonUtility.FromJson<saveErrors>(jsonString));



    }

    public static void LoadGameInfoError(string filename)
    {

        var jsonString = System.IO.File.ReadAllText(Application.dataPath + "/Saves/" + filename + "_1.json");
       errors.Add(JsonUtility.FromJson<saveErrors>(jsonString));

    }

    public static void SaveGameInfoError()
    {

        string game_data_string = JsonUtility.ToJson(errors[currentWorld]);
        System.IO.File.WriteAllText(Application.dataPath + "/Saves/" + errors[currentWorld].name + "_1.json", game_data_string);

    }
    public static void LoadOrStartGameErrors()
    {

        foreach (var filename in error_names)
        {
            if (System.IO.File.Exists(Application.dataPath + "/Saves/" + filename + "_1.json"))
            {
                LoadGameInfoError(filename);
            }
            else
            {
                LoadGameConfigError(filename);
            }
        }
    }




    public static void DeleteSaveings() 
    {
        foreach (var filename in error_names)
        {
            if (System.IO.File.Exists(Application.dataPath + "/Saves/" + filename + "_1.json"))
            {
                System.IO.File.Delete(Application.dataPath + "/Saves/" + filename + "_1.json");
            }
        }


        foreach (var filename in world_names)
        {
            if (System.IO.File.Exists(Application.dataPath + "/Saves/" + filename + "_1.json"))
            {
                System.IO.File.Delete(Application.dataPath + "/Saves/" + filename + "_1.json");
            }
        }
    }


    //--------------------------------------------------

    //aggiunta parte variabili errors
    public static void CompleatedLevel( float points, float[] w,float[] w2) 
    {

        if (points >= 4)
        {
            worlds[currentWorld].passedL1 = true;
        }
        worlds[currentWorld].total_pointsL1 = points;
        worlds[currentWorld].Completed();

        //salvo la percentuale di correttezza per parola (sostituibile con un ciclo for)
        if (errors[currentWorld].firstTime) 
        {
            errors[currentWorld].w1 = (w2[0] + w[0]);
            errors[currentWorld].w2 = (w2[1] + w[1]);
            errors[currentWorld].w3 = (w2[2] + w[2]);
            errors[currentWorld].w4 = (w2[3] + w[3]);
            errors[currentWorld].w5 = (w2[4] + w[4]);
            errors[currentWorld].w6 = (w2[5] + w[5]);
            errors[currentWorld].w7 = (w2[6] + w[6]);
            errors[currentWorld].w8 = (w2[7] + w[7]);
            errors[currentWorld].w9 = (w2[8] + w[8]);
            errors[currentWorld].w10 = (w2[9] + w[9]);

            errors[currentWorld].firstTime = false;
        }
        else if(errors[currentWorld].firstTime == false)
        {
            errors[currentWorld].w1_new = (w2[0] + w[0]);
            errors[currentWorld].w2_new = (w2[1] + w[1]);
            errors[currentWorld].w3_new = (w2[2] + w[2]);
            errors[currentWorld].w4_new = (w2[3] + w[3]);
            errors[currentWorld].w5_new = (w2[4] + w[4]);
            errors[currentWorld].w6_new = (w2[5] + w[5]);
            errors[currentWorld].w7_new = (w2[6] + w[6]);
            errors[currentWorld].w8_new = (w2[7] + w[7]);
            errors[currentWorld].w9_new = (w2[8] + w[8]);
            errors[currentWorld].w10_new  = (w2[9] + w[9]);
        }

        
    }

    //_---------------------------------------------

    public static void CollectFriend() 
    {
        worlds[currentWorld].friend = true;

            


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