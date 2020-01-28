using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;

    public float restartDelay = 1f;
    public GameObject tiltControl;
    public GameObject dragControl;
    public GameObject touchControl;

    public GameObject completeLevelUI;

    private GameState gameState;

    public void Awake()
    {
        //daBoss = (Titl)FindObjectOfType(typeof(Tilt));

        gameState = GetComponent<GameState>();
        //SetControlType();
    }


    public void SetControlType()
    {
        tiltControl = Instantiate(dragControl);
        if (string.Equals(gameState.GetControlType(), "drag"))
        {
            dragControl = Instantiate(dragControl);
        }
        else if (string.Equals(gameState.GetControlType(), "tilt"))
        {
            tiltControl = Instantiate(tiltControl);
        }
        else
        {
            touchControl = Instantiate(touchControl);
        }
    }

    public void CompleteLevel ()
	{
        Debug.Log("Saving current level");
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        gameState.SetLevel(SceneManager.GetActiveScene().buildIndex + 1);

        completeLevelUI.SetActive(true);
	}

	public void EndGame ()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			Debug.Log("GAME OVER");
			Invoke("Restart", restartDelay);
		}
	}

	public void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    public void PauseGame()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Menu");
    }
}
