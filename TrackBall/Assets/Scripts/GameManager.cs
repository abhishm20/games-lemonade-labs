using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;

    public float restartDelay = 1f;
    public float maxNoOfObstaclesAtATime = 5;
    public Transform player_transform;
    public GameObject obstacles_prefab;
    public GameObject level_prefab;
    public float respawnTime = 1.0f;
    private GameObject variableForPrefab;

    private float last_player_position;
    private GameState gameState;

    public void Awake()
    {
        gameState = GetComponent<GameState>();
        last_player_position = player_transform.position.z;
        StartCoroutine(asteroidWave());
    }

    private void FixedUpdate()
    {
        //createNewObstacles();
    }

    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            CreateNewObstacles();
        }
    }

    private void CreateNewObstacles()
    {
        // UnityScript
        variableForPrefab = Resources.Load("asteroids/astre_" + Random.Range(0,20)) as GameObject;
        last_player_position = player_transform.position.z;
        Vector3 position1 = new Vector3(Random.Range(-5, 5), Random.Range(1, 5), player_transform.position.z + 50);
        Instantiate(variableForPrefab, position1, Quaternion.identity);
    }


    public void CompleteLevel ()
	{
        //Debug.Log("Saving current level");
        //Debug.Log(SceneManager.GetActiveScene().buildIndex);
        //gameState.SetLevel(SceneManager.GetActiveScene().buildIndex + 1);

        //completeLevelUI.SetActive(true);
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
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene("Menu");
    }

    

}
