using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaHero : MonoBehaviour {
    public float upForce = 200;

    private Rigidbody2D rb2d;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0)){
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, upForce));
            anim.SetTrigger("Flip");
        }
	}
}
