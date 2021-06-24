using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxScore : MonoBehaviour
{
    GameHistoryData historyData;
    // Start is called before the first frame update
    void Start()
    {
        historyData = GameHistoryData.loadHistoryData();
        GetComponent<Text>().text = "Max Score: " + historyData.maxScore.ToString();
    }
}
