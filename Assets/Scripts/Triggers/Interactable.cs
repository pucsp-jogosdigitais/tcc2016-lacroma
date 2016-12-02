using UnityEngine;
using System.Collections;
using System;

public class Interactable : Trigger {

    public bool isSwitch = false;
    public bool actualState = false;
    public string tagName = "Player";

    public override void OnTriggerEnterOrStay2D(Collider2D other){
		if (Input.GetButtonDown("Interact") && tagName == other.tag) {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (isSwitch)
            {
                actualState = !actualState;
                if (actualState)
                    base.triggerFire(new EventArgs());
                else
                    base.triggerLeave(new EventArgs());
            }
            else
            {
                base.triggerFire(new EventArgs());
            }
        }
    }
}
