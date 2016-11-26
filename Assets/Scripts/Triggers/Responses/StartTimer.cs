using UnityEngine;
using System.Collections;
using System;

public class StartTimer : Response {

    public float wait;
    public Timer timer;

    protected override void triggerResponse(object sender, EventArgs e)
    {
        timer.startTimer(wait);
    }
}
