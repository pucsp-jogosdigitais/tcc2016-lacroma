using UnityEngine;
using System.Collections;
using System;

public class Jump : MonoChroma {

	#region constants
	public float baseHeight = 500.0f;
	public float bonusHeight = 500.0f;
	public float fallResistance = 350.0f;
	public float maxFallVelocity = 10.0f;
	public float fastFallResistance = 600.0f;
	#endregion

	#region variables
	public bool isNotGrounded;
    private bool wasNotGrounded;
    private bool buttonPressed;
	private ColorController jumpHeightBonus;
	private ColorController fallControlBonus;
	private float heightAdjustCoeficient = 0;
	private float controlAdjustCoeficient = 0;
    private Rigidbody2D rb;
    #endregion

    #region attributes
    public bool isJumping{
		get { return isNotGrounded; }
		set { isNotGrounded = value; }
	}
	#endregion

	void Start () {
		isNotGrounded = true;
		jumpHeightBonus = GameObject.FindWithTag ("RedController").GetComponent<ColorController> ();
		fallControlBonus = GameObject.FindWithTag ("BlueController").GetComponent<ColorController> ();
		jumpHeightBonus.ColorChange += setCoeficientValue;
		fallControlBonus.ColorChange += setFallBonusValue;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        buttonPressed = Input.GetButtonDown("Jump");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        wasNotGrounded = isNotGrounded;
        isNotGrounded = !checkGrounded();
		if (buttonPressed && !isNotGrounded && !(rb.velocity.y > 0)) {
			rb.AddForce (new Vector2 (0, baseHeight + heightAdjustCoeficient * bonusHeight), ForceMode2D.Impulse);
			isNotGrounded = true;
			gameObject.BroadcastMessage ("startJumping");
            buttonPressed = false;
		}
		if (rb.velocity.y < -maxFallVelocity) {
			float resistance = Math.Max ((float)Math.Pow (controlAdjustCoeficient, 4) * fastFallResistance, (float)Math.Pow (controlAdjustCoeficient, 3) * fallResistance);
			rb.AddForce (new Vector2 (0, resistance));
		}
		else if (rb.velocity.y < 0) {
			rb.AddForce (new Vector2 (0, (float)Math.Pow (controlAdjustCoeficient, 3) * fallResistance));
		}

        if (isNotGrounded)
            gameObject.BroadcastMessage("notGrounded");
        else
            gameObject.BroadcastMessage("isGrounded");

        gameObject.BroadcastMessage("verticalSpeed", rb.velocity.y);
	}

    private bool checkGrounded()
    {
        RaycastHit2D hit2;
        hit2 = Physics2D.Raycast(gameObject.transform.position, Vector2.down);
        return hit2.distance >= 0 && hit2.distance < 1.75f;
    }

	private void setCoeficientValue(object sender, ColorChangeEventArgs args){
		heightAdjustCoeficient = (float)args.Color;
	}

	void setFallBonusValue (object sender, ColorChangeEventArgs args){
		controlAdjustCoeficient = (float)args.Color;
	}
}
