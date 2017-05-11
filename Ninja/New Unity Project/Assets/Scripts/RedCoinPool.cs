using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCoinPool : MonoBehaviour {

	public GameObject redCoinPrefab;                                 //The column game object.

	public int poolSize = 5;
	public float spawnRate = 3f;                                    //How quickly columns spawn.

	public float xMin = -4.5f;
	public float xMax = 4.5f;
	public float xGapMin = 3.0f;

	public float yToNext = 5.3f;

	//private GameObject[] columns;
	private Queue<GameObject> columns = new Queue<GameObject>();

	private Vector2 objectPoolPostion;

	private float highestPositionY = -5f;
	private float highestPositionX = 0f;
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
		objectPoolPostion = new Vector2 (highestPositionX, highestPositionY);
		highestPositionY -= yToNext;

		for (int i = 0; i < poolSize; i++) {
			float spawnXPosition = getXGap (highestPositionX);

			if (i == 0) {
				spawnXPosition = 0;
			}

			highestPositionX = spawnXPosition;

			highestPositionY = highestPositionY + yToNext;
			objectPoolPostion = new Vector2 (spawnXPosition, highestPositionY);

			GameObject tmpObj = (GameObject)Instantiate(redCoinPrefab, objectPoolPostion, Quaternion.identity);
			columns.Enqueue (tmpObj); 
		}
	}

	// Update is called once per frame
	void Update () {

	}

	private float getXGap(float lastXposition)
	{
		float xgap = 0;
		while (true) {
			 xgap = Random.Range(xMin, xMax);
			if (Mathf.Abs(xgap-lastXposition) > xGapMin) {
				return xgap;
			}
		}
	}

	public void UpdateCurrentUsedCount()
	{
		currentUsedCount += 1;
		Debug.Log ("highest = " + highestPositionY + "Q size "+ columns.Count);
		if (currentUsedCount > 2) {
			moveLastOneToTop ();
		}

	}

	void moveLastOneToTop(){
		GameObject lowest = columns.Dequeue ();
		float spawnXPosition = getXGap (highestPositionX);

		highestPositionX = spawnXPosition;
		highestPositionY = highestPositionY + yToNext;
		lowest.transform.position = new Vector2(spawnXPosition, highestPositionY);
		lowest.GetComponent<RedCoin> ().used = false;
		columns.Enqueue (lowest);
	}
}
