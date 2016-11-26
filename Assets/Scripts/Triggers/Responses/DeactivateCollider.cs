using UnityEngine;
using System;

public class DeactivateCollider : Response {

    protected override void triggerResponse(object sender, EventArgs e)
    {
		foreach (Collider2D c in gameObject.GetComponents<Collider2D> ()) {
			c.enabled = false;
		}
	}

}
