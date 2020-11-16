using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destroySound;
    [SerializeField] GameObject blockFVX;
    [SerializeField] Sprite[] hitSprites;

    // cached Ref
    Level level;

    [SerializeField] int timesHit;

    private void Start()
    {
        CountBreabableBlocks();
    }

    private void CountBreabableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandHits();
        }
    }

    private void HandHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("block sprite is missing from array");
        }
    }

    private void DestroyBlock()
    {
        blockSoundSFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        destroyBlockFVX();
    }

    private void blockSoundSFX()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
    }

    private void destroyBlockFVX()
    {
        GameObject sparkelsFVX = Instantiate(blockFVX, transform.position, transform.rotation );
        Destroy(sparkelsFVX, 2f);
    }

}
