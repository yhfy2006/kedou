using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject player;
	private float verticalThreadhold;
    private Vector3 offset;

	public float gameOverThread = 5.0f;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
		verticalThreadhold = offset.y;
	}
	
	// Update is called once per frame
	void Update () {

		if ((transform.position.y - player.transform.position.y) > 10.0f) {
			float a = transform.position.y - player.transform.position.y;
			//print ("===>" + a);
			GameControl.instance.gameOver = true;
		}

		if (verticalThreadhold > (transform.position.y - player.transform.position.y)) {
			transform.position = new Vector3(transform.position.x, player.transform.transform.position.y + offset.y*2/5, player.transform.transform.position.z + offset.z);
			verticalThreadhold = transform.position.y - player.transform.position.y;
		}


	}
		
}
