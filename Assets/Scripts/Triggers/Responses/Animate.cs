using UnityEngine;
using System.Collections;
using System;

public class Animate : Response {

    private static readonly string[] ANIMATION_REFENCE = { "Bool", "Int", "Float", "Once" };

    public GameObject target;
    public string targetTag = "";
    public AnimationType type;
    public bool B = false;
    public float F = 0;
    public int I = 0;
    public string Name;

    void Start()
    {
        if (targetTag != "" && target == null)
            target = GameObject.FindGameObjectWithTag(targetTag);

        setTriggers();
    }


    protected override void triggerResponse(object sender, EventArgs e)
    {
        AnimateArgs args = new AnimateArgs(Name);
        args.B = B;
        args.F = F;
        args.I = I;
        target.BroadcastMessage("animate" + ANIMATION_REFENCE[(int)type], args);
    }

}
