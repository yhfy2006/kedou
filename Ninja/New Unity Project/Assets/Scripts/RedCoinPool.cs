using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCoinPool : MonoBehaviour {

	public GameObject redCoinPrefab;                                 //The column game object.

	public int poolSize = 5;
	public float spawnRate = 3f;                                    //How quickly columns spawn.

	public float xMin = -4.5f;
	public float xMax = 4.5f;

	public float yToNext = 5.3f;

	private GameObject[] columns;
	private Vector2 objectPoolPostion = new Vector2 (-15f, -25f);

	private int currentColumn = 1;      

	private float spawnXPosition = 10f;

	private int highestPositionIndex = 0;
	// Use this for initialization

	public int currentUsedCount = 0;
	public int coinMoveUpFrequency = 2;

	public static RedCoinPool instance;


	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	void Start () {
		columns = new GameObject[poolSize];

		objectPoolPostion = new Vector2 (0, -5);
		columns [0] = (GameObject)Instantiate (redCoinPrefab, objectPoolPostion, Quaternion.identity);
		for (int i = 1; i < poolSize; i++) {
			float spawnXPosition = Random.Range(xMin, xMax);
			float y = columns [i - 1].transform.position.y + yToNext;
			objectPoolPostion = new Vector2 (spawnXPosition, y);
			columns[i] = (GameObject)Instantiate(redCoinPrefab, objectPoolPostion, Quaternion.identity);
		}
		highestPositionIndex = poolSize - 1;
	}

	// Update is called once per frame
	void Update () {
		//print ("current U C:" + currentUsedCount);
		if (currentUsedCount != 0 && currentUsedCount % coinMoveUpFrequency == 0) {
			moveLastOneToTop ();
		}
	}

	void moveLastOneToTop(){
		for (int i = 0; i < poolSize; i++) {
			GameObject currentRedCoin = columns [i];

			if (currentRedCoin.GetComponent<RedCoin> ().used == true) {
				float spawnXPosition = Random.Range(xMin, xMax);
				GameObject highestRedCoin = columns [highestPositionIndex];
				columns[i].transform.position = new Vector2(spawnXPosition, highestRedCoin.transform.position.y + yToNext);

				highestPositionIndex = i;
				currentRedCoin.GetComponent<RedCoin> ().used = false;
			}
			break;
		}
	}
}
