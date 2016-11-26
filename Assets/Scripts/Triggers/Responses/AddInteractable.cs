using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AddInteractable : Response {
    public List<Response> responses;
    public GameObject target;

    void Start()
    {
        if (target == null)
            target = gameObject;
    }

    protected override void triggerResponse(object sender, EventArgs e)
    {
        Interactable inter = target.AddComponent<Interactable>();
        inter.isSwitch = false;
        foreach (Response resp in responses)
            resp.addTrigger(inter);

        Destroy(this);
    }
}
