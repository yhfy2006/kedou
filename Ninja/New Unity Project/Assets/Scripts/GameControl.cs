using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	public static GameControl instance;

	private Vector3 playerPosition;
	private float playerOffGroundY;
	public  bool playerStartAction = false;

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
		print (position);
	}

	public Vector3 getPlayerHeight()
	{
		return playerPosition;
	}

}
