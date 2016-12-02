using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Heal : ActionEffects
{
    public int heal;

    public override void standardExecute(GameObject sender, List<GameObject> targets)
    {
        CombatCharacter senderCharacter = sender.GetComponent<CombatCharacter>();
        foreach (GameObject target in targets)
        {
            gameObject.GetComponent<Acao>().acaoName = "Heal";
            CombatCharacter targetCharacter = target.GetComponent<CombatCharacter>();
            targetCharacter.healDamage(heal);
        }
    }

}
