using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class WeakTarget : BaseState {

    //public override GameObject getNextAction(List<GameObject> moves, CombatController controller)
    //{
    //    GameObject attack = Instantiate(moves[0]);
    //    Acao acao = attack.GetComponent<Acao>();
    //    acao.transform.parent = gameObject.transform;
    //    acao.Sender = gameObject;

    //    AcaoTargets acaoTargets = attack.GetComponent<AcaoTargets>();
    //    acaoTargets.setTargetList();
    //    List<GameObject> targets = acaoTargets.Targets;
    //    for (int i = 0; i < targets.Count; i++)
    //    {
    //        CombatCharacter character = targets[i].GetComponent<CombatCharacter>();
    //        if ((float)character.currentHP / character.maxHP < 0.5)
    //        {
    //            acao.Target = new List<GameObject> { targets[i] };
    //            break;
    //        }
    //    }
    //    controller.standardActions.Insert(0, acao);

    //    return attack;
    //}

    protected override void getActionTarget()
    {
        List<GameObject> result = new List<GameObject>();
        List<GameObject> targets = currentAction.gameObject.GetComponent<AcaoTargets>().Targets;
        for (int i = 0; i < targets.Count; i++)
        {
            CombatCharacter character = targets[i].GetComponent<CombatCharacter>();
            if ((float)character.currentHP / character.maxHP < 0.5)
            {
                currentAction.Target = new List<GameObject> { targets[i] };
                break;
            }
        }
    }

    public override bool getNextState()
    {
        List<GameObject> targets = moves[0].GetComponent<AcaoTargets>().Targets;
        foreach (GameObject target in targets)
        {
            CombatCharacter character = target.GetComponent<CombatCharacter>();
            if ((float)character.currentHP / character.maxHP < 0.5)
            {
                return false;
            }
        }
        gameObject.AddComponent<BaseState>();
        Destroy(this);
        return true;
    }
}
