using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Remoting.Channels;

public class ColorControl1 : MonoBehaviour {

	#region variables
	double currentColor;
	#endregion

	#region events
	public delegate void ColorChangeHandler (object sender, ColorChangeEventArgs args);
	public event ColorChangeHandler OnColorChange;
	#endregion

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.Alpha1)) {
			currentColor = 360.0f;
			if (OnColorChange != null)
				OnColorChange(this, new ColorChangeEventArgs(currentColor));
		}
		if (Input.GetKey (KeyCode.Alpha2)) {
			currentColor = 90.0f;
			if (OnColorChange != null)
				OnColorChange(this, new ColorChangeEventArgs(currentColor));
		}
		if (Input.GetKey (KeyCode.Alpha3)) {
			currentColor = 180.0f;
			if (OnColorChange != null)
				OnColorChange(this, new ColorChangeEventArgs(currentColor));
		}
		if (Input.GetKey (KeyCode.Alpha4)) {
			currentColor = 270.0f;
			if (OnColorChange != null)
				OnColorChange(this, new ColorChangeEventArgs(currentColor));
		}
		if (currentColor != degreesController()) {
			currentColor = degreesController ();
		}
		if (OnColorChange != null)
			OnColorChange(this, new ColorChangeEventArgs(currentColor));
	}

	private double degreesController(){
		double sin = Input.GetAxis ("Vertical_d");
		double cos = Input.GetAxis ("Horizontal_d");
		if (Math.Abs (Math.Pow (sin, 2) + Math.Pow (cos, 2) - 1) < 0.35) {
			return Mathf.Rad2Deg * Math.Atan2 (cos, sin) + 180.0;
		}
		else {
			return currentColor;
		}
	}
}

public class ColorChangeEventArgs : EventArgs{
	double color;

	public double Color{
		get { return color; }
	}

	public ColorChangeEventArgs(double c){
		color = c;
	}	
}