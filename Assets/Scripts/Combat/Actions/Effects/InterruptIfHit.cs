using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InterruptIfHit : ActionEffects
{

    public override void earlyExecute(GameObject sender, List<GameObject> targets)
    {
        CombatCharacter senderCharacter = sender.GetComponent<CombatCharacter>();
        if (senderCharacter.damageThisTurn > 0)
        {
            gameObject.name = "Fail";
            gameObject.GetComponent<Acao>().interrupted = true;
        }
    }

}
