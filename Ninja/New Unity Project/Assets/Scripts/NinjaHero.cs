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

	private bool facingRight = true;


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
		//print ("off Ground" + offGroundY);
		GameControl.instance.setPlayerOffGroundY (offGroundY);
		GameControl.instance.setPlayerPosition (rb2d.transform.position);

		//Input.GetTouch(0).deltaPosition.x < 0
		//if (Input.GetKeyUp("left") ) {
		if(SwipeManager.IsSwipingLeft())	{
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce(new Vector2(-upForce, 0));
			ninjaFlyOn (true);
			removeGravity ();
		}

		//if(Input.GetKeyUp("right") ){
		if(SwipeManager.IsSwipingRight()) {
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce(new Vector2(upForce, 0));
			ninjaFlyOn (true);
			removeGravity ();
		}



	}

	public void applyUpForce(){
		rb2d.velocity = Vector2.zero;
		rb2d.AddForce(new Vector2(0, upForce));
		anim.SetTrigger("Flip");
		//Debug.Log ("applied force"+upForce);
	}



	public void adjustFacing(){
		if (transform.position.x > 0 && facingRight) {

			transform.localRotation = Quaternion.Euler (0, 180, 0);
			facingRight = false;
		}

		if (transform.position.x <= 0 && !facingRight) {
			transform.localRotation = Quaternion.Euler (0, 0, 0);
			facingRight = true;
		}
	}


	public void ninjaFlyOn(bool on)
	{
		anim.SetBool ("Fly", on);
	}

	public void removeGravity()
	{
		rb2d.gravityScale = 0;
	}

	public void resumeGravity()
	{
		rb2d.gravityScale = gravityScale;
	}

	public void resetVelocity()
	{
		rb2d.velocity = Vector2.zero;
	}
}
