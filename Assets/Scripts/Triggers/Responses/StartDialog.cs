using UnityEngine;
using System.Collections;
using System;

public class StartDialog : Response {

    public GameObject dialog;

    protected override void triggerResponse(object sender, EventArgs args)
    {
        Instantiate(dialog);
    }
}
