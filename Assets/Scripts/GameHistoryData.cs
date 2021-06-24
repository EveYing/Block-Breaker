using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;

[Serializable]
public struct GameHistoryData
{
    public int maxScore;

    // read max score from history
    public static GameHistoryData loadHistoryData()
    {
        String savePath = getSavePath();
        GameHistoryData historyData;
        try
        {
            string text = System.IO.File.ReadAllText(savePath);
            historyData = JsonUtility.FromJson<GameHistoryData>(text);
        }
        catch (FileNotFoundException)
        {
            historyData.maxScore = 0;
        }
        return historyData;
    }

    // save game data
    public static void saveHistoryData(GameHistoryData historyData)
    {
        string text = JsonUtility.ToJson(historyData);
        System.IO.File.WriteAllText(getSavePath(), text);
    }

    private static String getSavePath()
    {
        return Application.persistentDataPath + "/gameData.json";
    }
}


