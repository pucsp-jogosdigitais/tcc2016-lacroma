using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ToggleScript : Response {

    public bool toggleOnLeave = false;
    public bool activate = false;
    public List<MonoBehaviour> scripts;

    protected override void triggerResponse(object sender, EventArgs e)
    {
        Debug.Log("Toggle: " + activate);
        foreach(MonoBehaviour script in scripts)
            script.enabled = activate;
    }

    protected override void leaveResponse(object sender, EventArgs e)
    {
        if (toggleOnLeave)
            foreach (MonoBehaviour script in scripts)
                script.enabled = !activate;
    }
}
