using UnityEngine;
using System.Collections;

public class StatModifier : MonoBehaviour {

    private int attack;
    private int defense;
    private int priority;

    /*0 on both this variables denote the standard behavior 
     * which means, effective this turn and ends with it*/
    private int duration = 0;
    private int turnsUntilActive = 0;

    public int Attack
    {
        get
        {
            return attack;
        }

        set
        {
            attack = value;
        }
    }

    public int Defense
    {
        get
        {
            return defense;
        }

        set
        {
            defense = value;
        }
    }

    public int Priority
    {
        get
        {
            return priority;
        }

        set
        {
            priority = value;
        }
    }

    public int Duration
    {
        set
        {
            duration = value;
        }
    }

    public int SetStart
    {
        set { turnsUntilActive = value; }
    }

    public bool IsActive
    {
        get { return !(turnsUntilActive > 0); }
    }

    public void endTurn()
    {
        if (IsActive)
        {
            if (duration == 0)
                Destroy(this);
            else
                duration--;
        }
        else
        {
            turnsUntilActive--;
        }
        
    }
}
