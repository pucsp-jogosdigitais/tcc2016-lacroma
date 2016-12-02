using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JarCounter : CombatAI {

    public override bool getNextState()
    {
        if (controller.turnCounter % 2 == 0)
        {
            if (rand.Next(2) > 0)
            {
                gameObject.AddComponent<JarInterrupt>();
                Destroy(this);
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }

    protected override void getNextAction()
    {
        GameObject nextAttack = character.getAttack(1);
        currentAction = nextAttack.GetComponent<Acao>();
        currentAction.transform.parent = gameObject.transform;
        currentAction.Sender = gameObject;
        //animate
    }

    protected override void getActionTarget()
    {
        List<GameObject> targets = currentAction.gameObject.GetComponent<AcaoTargets>().Targets;
        currentAction.Target = new List<GameObject> { targets[rand.Next(0, targets.Count)] };
    }

    protected override void getActionPlace()
    {
        controller.standardActions.Add(currentAction);
        currentAction.Place = 0;
    }
}
