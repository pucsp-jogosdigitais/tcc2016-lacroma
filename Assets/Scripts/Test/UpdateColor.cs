using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UpdateColor : MonoBehaviour {

	private static readonly string[] COLOR_REFENCE = {"Red", "Green", "Blue", "Yellow"};

	public string colorName;
	public ColorName color;
	private ColorController controller;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindWithTag(COLOR_REFENCE[(int)color]+"Controller").GetComponent<ColorController> ();
		controller.ColorChange += updateText;
	}
	
	private void updateText(object sender, ColorChangeEventArgs args){
		gameObject.GetComponent<Text> ().text = colorName + args.Color.ToString("F1");
	}
}
