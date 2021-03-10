using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    GameObject menuGameSession;

    private void Awake()
    {
        //Gets rid of the menu game session if it exists
        if (GameObject.Find("Menu_GameSession"))
        {
            gameObject.SetActive(false);
            Destroy(GameObject.Find("Menu_GameSession"));
        }
        

        //example of the Singleton pattern
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        this.livesText.text = playerLives.ToString();
        this.scoreText.text = score.ToString();
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    private void TakeLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        this.livesText.text = this.playerLives.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void ResetLivesAndScore()
    {
        playerLives = 3;
        score = 0;
        this.livesText.text = this.playerLives.ToString();
        this.scoreText.text = this.score.ToString();
    }

}
