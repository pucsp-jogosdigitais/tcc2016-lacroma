using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetRandomTarget : ActionRetarget {

    public override void retarget(Acao acao)
    {
        for(int i = 0; i < acao.Target.Count; i++)
        {
            CombatCharacter character = acao.Target[i].GetComponent<CombatCharacter>();
            if (!character.isAlive())
            {
                acao.Target[i] = gameObject.GetComponent<AcaoTargets>().getRandomTarget();
            }
        }
    }

}
