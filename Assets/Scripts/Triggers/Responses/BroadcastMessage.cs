using UnityEngine;
using System.Collections;
using System;

public class BroadcastMessage : Response {

    public string functionName;
    public string leaveName;

    protected override void triggerResponse(object sender, EventArgs e)
    {
        gameObject.BroadcastMessage(functionName, SendMessageOptions.DontRequireReceiver);
    }

    protected override void leaveResponse(object sender, EventArgs e)
    {
        gameObject.BroadcastMessage(leaveName, SendMessageOptions.DontRequireReceiver);
    }

}
