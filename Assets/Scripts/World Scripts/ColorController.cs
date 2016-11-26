using UnityEngine;
using System.Collections;
using System;

public abstract class ColorController : MonoBehaviour {

	#region events
	public delegate void ColorChangeHandler (object sender, ColorChangeEventArgs args);
	public event ColorChangeHandler ColorChange;
	#endregion

	public ColorControl1 controller;
	// Use this for initialization
	void Start () {
		controller.OnColorChange += newColorValue;	
	}

	protected void OnColorChange(ColorChangeEventArgs args){
		if (ColorChange != null)
			ColorChange (this, args);
	}

	protected abstract void newColorValue (object sender, ColorChangeEventArgs args);
}
