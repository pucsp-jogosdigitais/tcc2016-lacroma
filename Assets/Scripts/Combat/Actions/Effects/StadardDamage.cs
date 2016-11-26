using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StadardDamage : ActionEffects {

    public override void standardExecute(GameObject sender, List<GameObject> targets)
    {
        CombatCharacter senderCharacter = sender.GetComponent<CombatCharacter>();
        foreach (GameObject target in targets)
        {
            CombatCharacter targetCharacter = target.GetComponent<CombatCharacter>();

            targetCharacter.takeDamage(senderCharacter.Attack - targetCharacter.Defense);
        }
    }

}
