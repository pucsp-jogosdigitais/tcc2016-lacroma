using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AllEnemies : AcaoTargets
{
    public override void setTargetList()
    {
        targets = controller.enemyList;
    }

    public override List<GameObject> setTarget()
    {
        return targets;
    }

}