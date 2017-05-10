using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCoin : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponents<NinjaHero> () != null) {
			NinjaHero.instance.resumeGravity ();
			NinjaHero.instance.applyUpForce ();
		}
	}
}
