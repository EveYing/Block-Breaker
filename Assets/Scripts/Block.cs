using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip destroySound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // cached refs
    Level level;
    GameSession gs;

    // state variables
    int timesHit = 0; 

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gs = FindObjectOfType<GameSession>();
        if (gameObject.tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Breakable")
        {
            timesHit++;
            if (timesHit >= hitSprites.Length)
            {
                PlayBlockDestroySFX();
                DestroyBlock();
                TriggerSparklesVFX();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
        else
        {
            return;
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        gs.AddToScore();
        level.CountDestroyedBlocks();
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
        Destroy(gameObject);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
