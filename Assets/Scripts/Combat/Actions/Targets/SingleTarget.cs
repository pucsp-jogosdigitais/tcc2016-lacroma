using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingleTarget : AcaoTargets
{
    public override void setTargetList()
    {
        List<GameObject> playerChars = GameObject.FindGameObjectWithTag("CombatController").GetComponent<CombatController>().playerList;
        List<GameObject> enemyChars = GameObject.FindGameObjectWithTag("CombatController").GetComponent<CombatController>().enemyList;
        if (playerChars.Count > 1)
        {
            GameObject first = playerChars[0];
            playerChars.Remove(first);
            playerChars.Insert(1, first);
            currentlySelected = 1;
        }
        if (enemyChars.Count > 1)
        {
            GameObject first = enemyChars[0];
            enemyChars.Remove(first);
            enemyChars.Insert(1, first);
        }
        playerChars.Reverse();
        enemyChars.Reverse();

        targets = new List<GameObject>(playerChars);
        targets.AddRange(enemyChars);
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