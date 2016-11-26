using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnyTwo : AcaoTargets {

    List<GameObject> result = new List<GameObject>();

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
        if (result.Count == 2)
            return result;
        else
        {
            GameObject nextTarget = selectTarget(targets.ToArray());
            if(nextTarget != null)
            {
                result.Add(nextTarget);
                targets.Remove(nextTarget);
            }
            return new List<GameObject>();
        }
    }
}
