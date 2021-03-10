using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    //[SerializeField] int maxHits; //Moved this to HandleHit() since we can reference our array there and adjust based on the block
    [SerializeField] Sprite[] hitSprites;

    //Cached reference
    Level level;

    //state variables
    [SerializeField] int timesHit; //Only serialized for debugging purposes

    private void Start()
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
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock(); //We could leave the code below inside this function, but since it's a system-created method, it's good practice to refactor as much as possible
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
            Debug.LogError("Block sprite is missing from array" + gameObject.name); //Good thing to get into the habit of. Putting in error checking for easy mistakes
        }
    }

    private void DestroyBlock()
    {
        //Playing the clip at the camera's position
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        //Destroying the block that the ball collides with
        Destroy(gameObject, 0f);

        //Calls the sparkles visual effect, if the block has one
        if (blockSparklesVFX != null)
        {
            TriggerSparkles();
        }
        
        //Calling the method to decrease the total count of blocks
        level.BlockDestroyed();

        //Calling the method to increase the score per block destroyed
        FindObjectOfType<GameSession>().AddToScore();
        //^^^^^^ Could've been written as vvvvvv - The single line approach is more legible for our code
        //gameStatus = FindObjectOfType<GameStatus>();
        //gameStatus.AddToScore();

        /* Simple way to look at what collision took place
         * Debug.Log(collision.gameObject.name); */
    }

    private void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }


}
