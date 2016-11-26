using UnityEngine;
using System.Collections;
using System;

public class CallTrigger : Trigger {

    public void callTrigger()
    {
        base.triggerFire(new EventArgs());
    }

    public void callLeave()
    {
        base.triggerLeave(new EventArgs());
    }

}
