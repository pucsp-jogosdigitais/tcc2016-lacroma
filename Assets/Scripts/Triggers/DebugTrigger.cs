using UnityEngine;
using System.Collections;
using System;

public class DebugTrigger : Trigger {

    public KeyCode enterKey;
    public KeyCode leaveKey;

	void Update () {
        if (Input.GetKeyDown(enterKey))
            base.triggerFire(new EventArgs());
        if (Input.GetKeyDown(leaveKey))
            base.triggerLeave(new EventArgs());
	}
}
