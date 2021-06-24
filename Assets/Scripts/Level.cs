using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int breakableBlocks = 0;
    int brokenBlocks = 0;
    Ball ball;
    [SerializeField] GameObject successScreen;

    SceneLoader sl;
    GameSession gs;

    private void Start()
    {
        sl = FindObjectOfType<SceneLoader>();
        ball = FindObjectOfType<Ball>();
        gs = FindObjectOfType<GameSession>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void CountDestroyedBlocks()
    {
        brokenBlocks++;
        if (brokenBlocks >= breakableBlocks)
        {
            //sl.LoadNextScene();
            ball.GetComponent<Rigidbody2D>().Sleep();
            successScreen.SetActive(true);
            var historyData = GameHistoryData.loadHistoryData();
            if (historyData.maxScore < gs.currentScore)
            {
                historyData.maxScore = gs.currentScore;
                GameHistoryData.saveHistoryData(historyData);
            }
        }
    }

    public int getBrokenBlocks()
    {
        return brokenBlocks;
    }
}
