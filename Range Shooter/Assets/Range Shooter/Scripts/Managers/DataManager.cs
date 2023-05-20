using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class GameData
{
    public string PlayerName;
    public string BestPlayerName;
    public int PlayerScore;
    public int BestScoe;
    public int PlayerCurrency;
    public bool HasRiffle;
}
public class DataManager : MonoBehaviour
{
    public static GameData GameData;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        GameData = Load();

        if(GameData == null)
        {
            GameData = new GameData();
        }
    }
    public static void Save()
    {
        string savePath = Application.persistentDataPath + "/Save.file";

        if (GameData != null)
        {
            var json = JsonUtility.ToJson(GameData);
            File.WriteAllText(savePath, json);

            //print("Progress Saved");
        }
    }
    public static GameData Load()
    {
        string loadPath = Application.persistentDataPath + "/Save.file";

        if (!File.Exists(loadPath)) return null;

        var json = File.ReadAllText(loadPath);

        //print("Progress Loaded");

        return JsonUtility.FromJson<GameData>(json);
    }
    public static void DeleteSaveFile()
    {
        string savePath = Application.persistentDataPath + "/save.file";

        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }
    }
}
