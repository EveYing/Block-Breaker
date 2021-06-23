using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int breakableBlocks = 0;
    int brokenBlocks = 0;

    SceneLoader sl;

    private void Start()
    {
        sl = FindObjectOfType<SceneLoader>();
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
            sl.LoadNextScene();
        }
    }

    public int getBrokenBlocks()
    {
        return brokenBlocks;
    }
}
