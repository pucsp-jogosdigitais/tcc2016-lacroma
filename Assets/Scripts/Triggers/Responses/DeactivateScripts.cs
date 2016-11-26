using UnityEngine;
using System.Collections;
using System;

public class DeactivateScripts : Response {

	public MonoBehaviour [] deactivate;

	protected override void triggerResponse(object sender, EventArgs args){

		foreach (MonoBehaviour s in deactivate) {
			Destroy (s);
		}
		deactivate = new MonoBehaviour[0];
	}
}
