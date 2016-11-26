using UnityEngine;
using System.Collections;
using System;

public class DebugLog : Response {

    protected override void triggerResponse(object sender, EventArgs e)
    {
        Debug.Log("It Works!");
    }

    protected override void leaveResponse(object sender, EventArgs e)
    {
        Debug.Log("Leaving Works too!");
    }
}
