using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BaseState : CombatAI
{

    protected override void getNextAction()
    {
        GameObject nextAttack = character.getAttack(0);
        currentAction = nextAttack.GetComponent<Acao>();
        currentAction.transform.parent = gameObject.transform;
        currentAction.Sender = gameObject;
    }

    protected override void getActionTarget()
    {
        List<GameObject> targets = currentAction.gameObject.GetComponent<AcaoTargets>().Targets;
        currentAction.Target = new List<GameObject> { targets[rand.Next(0, targets.Count)] };
    }

    protected override void getActionPlace()
    {
        controller.standardActions.Insert(0, currentAction);
        currentAction.Place = 0;
    }

    //public override GameObject getNextAction()
    //{
    //    GameObject attack = Instantiate(moves[0]);
    //    Acao acao = attack.GetComponent<Acao>();
    //    acao.transform.parent = gameObject.transform;
    //    acao.Sender = gameObject;

    //    AcaoTargets acaoTargets = attack.GetComponent<AcaoTargets>();
    //    acaoTargets.setTargetList();
    //    List<GameObject> targets = acaoTargets.Targets;
    //    acao.Target = new List<GameObject> { targets[rand.Next(0, targets.Count)] };
    //    controller.standardActions.Insert(0, acao);        

    //    return attack;
    //}

    public override bool getNextState()
    {
        List<GameObject> targets = moves[0].GetComponent<AcaoTargets>().Targets;
        if (targets != null)
            foreach (GameObject target in targets)
            {
                CombatCharacter character = target.GetComponent<CombatCharacter>();
                if ((float)character.currentHP / character.maxHP < 0.5)
                {
                    gameObject.AddComponent<WeakTarget>();
                    Destroy(this);
                    return true;
                }
            }
        return false;
    }
}
