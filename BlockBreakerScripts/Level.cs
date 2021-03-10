using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //Parameters
    [SerializeField] int breakableBlocks; //Serialized for debugging purposes

    //Cached References
    SceneLoader sceneLoader;
    GameSession gameStatus;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameSession>();
    }

    //Counting the blocks in a level when it is loaded
    public void CountBlocks()
    {
        breakableBlocks++;
    }

    //Removes from the total number of blocks when one is destroyed
    //Then checks to see if it needs to congratulate and move to the next level
    public void BlockDestroyed()
    {
        breakableBlocks--;

        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
            gameStatus.IncreaseLevel();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
