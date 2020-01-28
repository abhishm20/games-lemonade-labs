using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameState gameState;

    private void Awake()
    {
        gameState = GetComponent<GameState>();
    }

    public void Continue()
    {
        Debug.Log("Fetched last level");
        Debug.Log(gameState.GetLevel());
        SceneManager.LoadScene("Level" + gameState.GetLevel());
    }

    public void StartNewGame()
    {
        gameState.SetLevel(1);
        SceneManager.LoadScene("Level"+1);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
