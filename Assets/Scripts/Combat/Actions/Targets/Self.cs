using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Self : AcaoTargets
{
    public override void setTargetList()
    {
        targets = controller.playerList;
    }

    public override List<GameObject> setTarget()
    {
        if (targets.Count == 1)
            return new List<GameObject>(targets);
        else
        {
            List<GameObject> result = new List<GameObject>();
            GameObject nextTarget = selectTarget(targets.ToArray());
            if (nextTarget != null)
            {
                result.Add(nextTarget);
                return result;
            }
            else
                return new List<GameObject>();
        }

    }
}
