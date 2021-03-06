﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	private BoxCollider2D backgroundCollider;
	private float groundVerticalLength;

	// Use this for initialization
	void Start () {
		backgroundCollider = GetComponent<BoxCollider2D> ();
		groundVerticalLength = backgroundCollider.size.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameControl.instance.getPlayerOffGroundY()> transform.position.y + groundVerticalLength + 5) {
			RepositionBackground ();
		}
	}

	private void RepositionBackground(){
		Vector2 groundOffset = new Vector2 (0, groundVerticalLength * 2f);
		transform.position = (Vector2)transform.position + groundOffset;
	}

	void OnTriggerEnter2D(Collider2D other) {
		//print ("hi");
		if (other.GetComponents<NinjaHero> () != null) {
			NinjaHero.instance.resetVelocity ();
			NinjaHero.instance.resumeGravity ();
		}
	}
}



//public class RepeatingBackground : MonoBehaviour {
//
//	private BoxCollider2D groundCollider;
//	private float groundHorizontalLength;
//	// Use this for initialization
//	void Start () {
//		groundCollider = GetComponent<BoxCollider2D> ();
//		groundHorizontalLength = groundCollider.size.x;
//	}
//
//	// Update is called once per frame
//	void Update () {
//		if (transform.position.x < -groundHorizontalLength) {
//			RepositionBackground ();
//		}
//	}
//
//	private void RepositionBackground(){
//		Vector2 groundOffset = new Vector2 (groundHorizontalLength * 2f, 0);
//		transform.position = (Vector2)transform.position + groundOffset;
//
//	}
//}