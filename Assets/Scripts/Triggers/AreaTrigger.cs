using UnityEngine;
using System.Collections;
using System;

public class AreaTrigger : Trigger {

	public string tagName = "";

	public override void OnTriggerEnterOrStay2D(Collider2D other){
		
		if (tagName == "" || tagName == other.tag) {
            base.triggerFire(new EventArgs());
		}
	}

    void OnTriggerExit2D()
    {
        base.triggerLeave(new EventArgs());
    }

}
