using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCoin : MonoBehaviour {

	public bool used = false;

	public float targetTimeValue = 5.0f;


	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponents<NinjaHero> () != null) {
			NinjaHero.instance.resumeGravity ();
			NinjaHero.instance.applyUpForce ();

			if (!used) {
				RedCoinPool.instance.UpdateCurrentUsedCount ();
			}
			used = true;
		}
	}
}
