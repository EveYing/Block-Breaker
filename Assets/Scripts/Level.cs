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

    private void Start()
    {
        sl = FindObjectOfType<SceneLoader>();
        ball = FindObjectOfType<Ball>();
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
        }
    }

    public int getBrokenBlocks()
    {
        return brokenBlocks;
    }
}
