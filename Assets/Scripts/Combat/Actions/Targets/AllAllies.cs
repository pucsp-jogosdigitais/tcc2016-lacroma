using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AllAllies : AcaoTargets
{
    public override void setTargetList()
    {
        targets = controller.playerList;
    }

    public override List<GameObject> setTarget()
    {
        return targets;
    }

}