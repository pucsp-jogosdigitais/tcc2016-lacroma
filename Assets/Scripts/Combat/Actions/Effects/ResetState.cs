using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetState : ActionEffects
{
    public string[] states;

    public override void lateExecute(GameObject sender, List<GameObject> targets)
    {
        foreach (string state in states)
            BroadcastMessage("animateStop", state);
    }

}
