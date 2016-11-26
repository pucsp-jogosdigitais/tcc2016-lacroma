using UnityEngine;
using System.Collections;
using System;

public class Move : MonoBehaviour {

	#region constants
	public float maxSpeedBase = 30.0f;
	public float maxSpeedAdjust = 20.0f;
	public float maxAirSpeedBase = 5.0f;
	public float maxAirSpeedAdjust = 15.0f;
	public float brakeForce = 1400.0f;
	public float baseForce = 800.0f;
	public float baseAirSpeedChange = 800.0f;
	public float bonusForce = 800.0f;
	public float bonusAirSpeed = 800.0f;
    public float slopeAdjust = 1400.0f;
	#endregion

	#region variables
	private ColorController groundedSpeedController;
	private ColorController airSpeedController;
	private float groudSpeedAdjustCoeficient = 0;
	private float airSpeedAdjustCoeficient = 0;
	private bool isJumping;
    private float move;
    Rigidbody2D rb;
    #endregion

    public LayerMask mask = -1;

    void Start () {
		groundedSpeedController = GameObject.FindWithTag ("YellowController").GetComponent<ColorController> ();
		airSpeedController = GameObject.FindWithTag ("BlueController").GetComponent<ColorController> ();
		groundedSpeedController.ColorChange += setGroundedSpeedBonus;
		airSpeedController.ColorChange += setAirSpeedBonus;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
    }

	// Update is called once per frame
	void FixedUpdate () {
		//isJumping = gameObject.GetComponent<Jump> ().isJumping;

		#region grounded movement
		if (Math.Abs(rb.velocity.x) < maxSpeedBase + groudSpeedAdjustCoeficient * maxSpeedAdjust && !isJumping) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 10f, mask);


            if (Mathf.Abs(hit.normal.x) > 0)
            {
                if(Math.Sign(move) != Math.Sign(hit.normal.x) && move != 0)
                    rb.AddForce(move * slopeAdjust * new Vector2(hit.normal.y, -hit.normal.x));
                else if (Mathf.Abs(hit.normal.x) < 5.6 && move == 0)
                    rb.AddForce(-Math.Sign(hit.normal.x) * slopeAdjust * new Vector2(hit.normal.y, -hit.normal.x));
            }

            if (Math.Sign(rb.velocity.x) == -Math.Sign(move) && Math.Abs(move) > 0.05)
				rb.AddForce (new Vector2 (Math.Sign(move) * brakeForce, 0));
			else{
				rb.AddForce (new Vector2 (move * (baseForce + groudSpeedAdjustCoeficient * bonusForce), 0));
			}

            BroadcastMessage("isMoving", Math.Sign(move) * rb.velocity.magnitude);

        }
		if (Math.Abs(move) < 0.1 && Math.Abs(rb.velocity.x) > 0.3f && !isJumping) {
			rb.AddForce (new Vector2 (Math.Sign(rb.velocity.x) * -brakeForce, 0));
		}
		#endregion

		#region ungrounded movement
		if ((Math.Abs(rb.velocity.x) < maxAirSpeedBase + groudSpeedAdjustCoeficient * maxAirSpeedAdjust || Math.Sign(move) != Math.Sign(rb.velocity.x)) && isJumping && Math.Abs(move) > 0.1) {
			rb.AddForce (new Vector2 (move * (baseAirSpeedChange + (float)Math.Pow(airSpeedAdjustCoeficient, 3) * bonusAirSpeed), 0));
		}
		#endregion
	}

	private void setGroundedSpeedBonus(object sender, ColorChangeEventArgs args){
		groudSpeedAdjustCoeficient = (float)args.Color;
	}

	void setAirSpeedBonus (object sender, ColorChangeEventArgs args){
		airSpeedAdjustCoeficient = (float)args.Color;
	}

	void notGrounded (){
		isJumping = true;
	}

	void isGrounded (){
		isJumping = false;
	}
}
