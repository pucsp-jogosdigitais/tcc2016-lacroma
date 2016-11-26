using UnityEngine;
using System;

public class ColorTrigger : Trigger {

	private static readonly string[] COLOR_REFENCE = {"Red", "Green", "Blue", "Yellow"};

	private GameObject origin;
	public ColorName color;
	public float maxDistance = 3.0f;
	private ColorController controller;
	public float tolerance = 0.1f;
	
	void Start () {
		origin = GameObject.FindWithTag ("Player");
		controller = GameObject.FindWithTag (COLOR_REFENCE[(int)color] + "Controller").GetComponent<ColorController> ();
		controller.ColorChange += trigger;
	}



	private void trigger(object sender, ColorChangeEventArgs args){
		if (Vector3.Distance(gameObject.transform.position, origin.transform.position) < maxDistance){
            if (1 - args.Color < tolerance)
            {
                base.triggerFire(new EventArgs());
            }
            else
            {
                base.triggerLeave(new EventArgs());
            }
		}
	}

    void OnDestroy(){
		controller.ColorChange -= trigger;
	}
}
