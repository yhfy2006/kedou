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

	//private GameObject[] columns;
	private Queue<GameObject> columns = new Queue<GameObject>();

	private Vector2 objectPoolPostion;

	private float highestPosition = -5f;
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
		objectPoolPostion = new Vector2 (0, highestPosition);

		GameObject tmpObj = (GameObject)Instantiate (redCoinPrefab, objectPoolPostion, Quaternion.identity);
		columns.Enqueue(tmpObj);

		for (int i = 1; i < poolSize; i++) {
			float spawnXPosition = Random.Range(xMin, xMax);
			highestPosition = highestPosition + yToNext;
			objectPoolPostion = new Vector2 (spawnXPosition, highestPosition);

			tmpObj = (GameObject)Instantiate(redCoinPrefab, objectPoolPostion, Quaternion.identity);
			columns.Enqueue (tmpObj); 
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void UpdateCurrentUsedCount()
	{
		currentUsedCount += 1;
		if (currentUsedCount != 0 && currentUsedCount % coinMoveUpFrequency == 0) {
			
			moveLastOneToTop ();
		}
	}

	void moveLastOneToTop(){
		Debug.Log ("herererer===>");
		GameObject lowest = columns.Dequeue ();
		float spawnXPosition = Random.Range(xMin, xMax);
		highestPosition = highestPosition + yToNext;
		lowest.transform.position = new Vector2(spawnXPosition, highestPosition);
		columns.Enqueue (lowest);
	}
}
