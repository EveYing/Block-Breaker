using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    GameSession gs;
    int finalScore;
    GameHistoryData historyData;
    string savedPath;

    // Start is called before the first frame update
    void Start()
    {
        // get final score
        gs = FindObjectOfType<GameSession>();
        finalScore = gs.currentScore;
        GetComponent<Text>().text = "Final Score: " + finalScore.ToString();

        historyData = GameHistoryData.loadHistoryData();
        if (historyData.maxScore < finalScore)
        {
            historyData.maxScore = finalScore;
            GameHistoryData.saveHistoryData(historyData);
        }
    }


}
