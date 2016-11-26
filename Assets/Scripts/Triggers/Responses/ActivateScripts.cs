using UnityEngine;
using System.Collections;
using System;

public class ActivateScripts : Response {

	public string [] activate;

    protected override void triggerResponse(object sender, EventArgs args)
    {

        foreach (string s in activate)
        {
            gameObject.AddComponent(Type.GetType(s));
        }
		activate = new string[0];
	}
}
