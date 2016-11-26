using UnityEngine;
using System.Collections;
using System;

public class Awake : Response {


   public float delay;

    protected override void triggerResponse(object sender, EventArgs e)
    {
        StartCoroutine(awake(delay));
    }

    private IEnumerator awake(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        foreach (Rigidbody2D r in gameObject.GetComponents<Rigidbody2D>())
        {
            r.WakeUp();
        }
    }
}
