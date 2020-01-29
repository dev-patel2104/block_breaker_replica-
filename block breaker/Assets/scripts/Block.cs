using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject breakSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] int timesHits;
    [SerializeField] Sprite[] hitSprites;
    level Level;

    gameSession  gamestatus;
   

    private void Start()
    {
        Level = FindObjectOfType<level>();
        gamestatus = FindObjectOfType<gameSession>();
        if (tag == "Breakable")
        {
            Level.countofblock();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHits++;
        if (timesHits >= maxHits)
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
        int spriteIndex = timesHits - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from the array");
            Debug.LogError("The GameObject is " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        gamestatus.AddToScore();
        Level.blockDestroy();
        Destroy(gameObject);
        TriggerSparkleEffect();
    }

    private void TriggerSparkleEffect()
    {
        GameObject sparkles = Instantiate(breakSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1.22f);
    }
}
