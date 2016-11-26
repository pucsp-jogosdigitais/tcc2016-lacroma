using UnityEngine;
using System.Collections;
using System;

public class Timer : Trigger {

    public void startTimer(float waitTime)
    {
        StartCoroutine(fire(waitTime));
    }

    private IEnumerator fire(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        base.triggerFire(new EventArgs());
    }

}
