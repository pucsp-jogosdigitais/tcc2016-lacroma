using UnityEngine;
using System;

public class DeactivateObject : Response {

    protected override void triggerResponse(object sender, EventArgs e)
    {
        gameObject.SetActive(false);
    }

}
