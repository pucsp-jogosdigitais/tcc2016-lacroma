using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class All : AcaoTargets
{

    public override void setTargetList()
    {
        targets = controller.charList;
    }

    public override List<GameObject> setTarget()
    {
        return targets;
    }
}