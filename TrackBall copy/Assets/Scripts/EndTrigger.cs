using UnityEngine;

public class EndTrigger : MonoBehaviour {

	public GameManager gameManager;

	void OnTriggerEnter ()
	{
        Debug.Log("End game object triggered");
		gameManager.CompleteLevel();
	}

}
