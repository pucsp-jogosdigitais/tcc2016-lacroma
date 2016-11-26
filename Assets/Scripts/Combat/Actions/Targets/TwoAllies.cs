using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TwoAllies : AcaoTargets
{
    List<GameObject> result = new List<GameObject>();

    public override void setTargetList()
    {
        targets = controller.playerList;
    }

    public override List<GameObject> setTarget()
    {
        if (result.Count == 2)
            return result;
        else
        {
            GameObject nextTarget = selectTarget(targets.ToArray());
            if (nextTarget != null)
            {
                result.Add(nextTarget);
                targets.Remove(nextTarget);
            }
            return new List<GameObject>();
        }
    }
}
