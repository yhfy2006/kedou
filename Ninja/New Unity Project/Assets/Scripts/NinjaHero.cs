using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaHero : MonoBehaviour {
    public float upForce = 200;

    private Rigidbody2D rb2d;
    private Animator anim;

	private float baseY;

	private float gravityScale = 6.5f;

	public static NinjaHero instance;


	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        anim = GetComponent<Animator>();
		baseY = rb2d.transform.position.y;
		gravityScale = rb2d.gravityScale;
    }

    // Update is called once per frame
    void Update () {
		float offGroundY = rb2d.transform.position.y - baseY;
		GameControl.instance.setPlayerOffGroundY (offGroundY);
		GameControl.instance.setPlayerPosition (rb2d.transform.position);

		if (Input.GetMouseButtonUp (0)) {
			rb2d.AddForce(new Vector2(-upForce, 0));
			rb2d.velocity = Vector2.zero;
			removeGravity ();
		}

		if (Input.GetMouseButtonUp (1)) {
			rb2d.AddForce(new Vector2(upForce, 0));
			rb2d.velocity = Vector2.zero;
			removeGravity ();
		}

	}

	public void applyUpForce(){
		rb2d.velocity = Vector2.zero;
		rb2d.AddForce(new Vector2(0, upForce));
		anim.SetTrigger("Flip");
		if (GameControl.instance.playerStartAction == false) {
			GameControl.instance.playerStartAction = true;
		}
	}

	public void removeGravity()
	{
		rb2d.gravityScale = 0;
	}

	public void resumeGravity()
	{
		rb2d.gravityScale = gravityScale;
	}
}
