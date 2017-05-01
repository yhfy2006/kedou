using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

	public GameObject columnPrefab;                                 //The column game object.

	public int columnPoolSize = 5;
	public float spawnRate = 3f;                                    //How quickly columns spawn.

	public float columnMin = -1f;
	public float columnMax = 3.5f;

	private GameObject[] columns;
	private Vector2 objectPoolPostion = new Vector2 (-15f, -25f);

	private int currentColumn = 0;      

	private float spawnXPosition = 10f;

	private float timeSinceLastSpawned;
	// Use this for initialization
	void Start () {
		columns = new GameObject[columnPoolSize];
		for (int i = 0; i < columnPoolSize; i++) {
			columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPostion, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastSpawned += Time.deltaTime;
		if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) {
			timeSinceLastSpawned = 0;
			float spawnYPosition = Random.Range(columnMin, columnMax);

			//...then set the current column to that position.
			columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

			currentColumn ++;

			if (currentColumn >= columnPoolSize) 
			{
				currentColumn = 0;
			}
		}
	}
}
