using UnityEngine;
using System.Collections;
using System;

public class ParticleColor : MonoBehaviour {

	private float redHue = 0.0f;
	private float blueHue = 135.0f;
	private float greenHue = 260.0f;
	private float yellowHue = 295.0f;

	private float redValue;
	private float blueValue;

	private ColorController red;
	private ColorController blue;

	void Start(){
		red = GameObject.FindWithTag ("RedController").GetComponent<ColorController> ();
		blue = GameObject.FindWithTag ("BlueController").GetComponent<ColorController> ();
		red.ColorChange += setRed;
		blue.ColorChange += setBlue;
	}

	// Update is called once per frame
	void Update () {
		Material particles = gameObject.GetComponent<ParticleSystemRenderer> ().material;
		particles.SetFloat ("_HueShift", getHue());
		particles.SetFloat ("_Val", getValue ());
	}

	private float getHue(){
		float redAxis = redValue * 2 - 1;
		float blueAxis = blueValue * 2 - 1;
		float redInfluence = (float)Math.Pow (redAxis, 2);
		float blueInfluence = (float)Math.Pow (blueAxis, 2);
		if (redAxis > 0 && blueAxis >= 0) {
			return (redHue * redInfluence + blueHue * blueInfluence);
		} else if (redAxis <= 0 && blueAxis > 0) {
			return (greenHue * redInfluence + blueHue * blueInfluence);
		} else if (redAxis < 0 && blueAxis <= 0) {
			return (greenHue * redInfluence + yellowHue * blueInfluence);
		} else {
			return ((redHue + 360.0f) * redInfluence + yellowHue * blueInfluence);
		}
	}

	private float getValue(){
		return 2;
		/*if (blueValue > 0.5)
			return 1.0f;
		else
			return 2 - blueValue * 2;*/
	}

	private void setRed(object sender, ColorChangeEventArgs args){
		redValue = (float)args.Color;
	}

	private void setBlue(object sender, ColorChangeEventArgs args){
		blueValue = (float)args.Color;
	}
}
