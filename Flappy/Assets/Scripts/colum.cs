using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colum : MonoBehaviour {
	private void OnTriggerEnter2D (Collider2D other){
		if (other.GetComponents<Bird> () != null) {
			GameControl.instance.BirdScored();
		}
	}

 
}
