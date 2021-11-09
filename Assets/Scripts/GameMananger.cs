using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameMananger : MonoBehaviour
{
    public static GameMananger Instance;


    public string playerName;


    public string highScoreName {get {return _highScoreName;}}
    private string _highScoreName;
    public int highscore {get {return _highscore;}}

    private int _highscore;

    public int score;


    private void Awake() {

        if(Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }


   

    public void HandleScore()
    {
        if(score > _highscore){
            _highscore = score;
            _highScoreName = playerName;
            score = 0;
        }else
        {
            score = 0;
        }
        
    }

[System.Serializable]
    class SaveData
    {
        public string highScoreName;
        public int highscore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScoreName = _highScoreName;
        data.highscore = _highscore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);

    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            _highscore = data.highscore;
            _highScoreName = data.highScoreName;
        }
    }
 






}
