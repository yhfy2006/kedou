using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public static GameControl instance;

	private Vector3 playerPosition;
	private float playerOffGroundY;
	public  bool playerStartAction = false;

	public bool gameOver = false;


	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver && Input.GetMouseButtonDown (0)) {
			resetGame ();
		}
	}

	public void resetGame()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		gameOver = false;
	}

	public void setPlayerOffGroundY(float y)
	{
		playerOffGroundY = y;
	}

	public float getPlayerOffGroundY()
	{
		return playerOffGroundY;
	}

	public void setPlayerPosition(Vector3 position)
	{
		playerPosition = position;
		//print (position);
	}

	public Vector3 getPlayerHeight()
	{
		return playerPosition;
	}
		

}
