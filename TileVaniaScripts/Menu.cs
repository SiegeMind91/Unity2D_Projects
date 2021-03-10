using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GameSession gameSession;

    public void StartFirstLevel()
    { 
        SceneManager.LoadScene(1);
        FindObjectOfType<GameSession>().ResetLivesAndScore();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
