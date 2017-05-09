using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaHero : MonoBehaviour {
    public float upForce = 200;

    private Rigidbody2D rb2d;
    private Animator anim;

	private float baseY;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        anim = GetComponent<Animator>();
		baseY = rb2d.transform.position.y;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0)){
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, upForce));
            anim.SetTrigger("Flip");
			if (GameControl.instance.playerStartAction == false) {
				GameControl.instance.playerStartAction = true;
			}
        }
		float offGroundY = rb2d.transform.position.y - baseY;
		GameControl.instance.setPlayerOffGroundY (offGroundY);
		GameControl.instance.setPlayerPosition (rb2d.transform.position);
	}
}
