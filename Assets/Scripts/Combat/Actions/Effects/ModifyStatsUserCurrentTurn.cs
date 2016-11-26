using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModifyStatsUserCurrentTurn : ActionEffects {

    public int turnsUntilStart = 0;
    [Tooltip("-1 for until the end of the battle")]
    public int duration = 0;
    public int attack = 0;
    public int defense = 0;
    public int priority = 0;

    public override void earlyExecute(GameObject sender, List<GameObject> targets)
    {
        StatModifier modifier = sender.AddComponent<StatModifier>();
        modifier.Attack = attack;
        modifier.Defense = defense;
        modifier.Priority = priority;
        modifier.Duration = duration;
        modifier.SetStart = turnsUntilStart;
    }

}
