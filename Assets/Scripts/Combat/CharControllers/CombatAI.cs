using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class CombatAI : CombatCharacterController
{

    protected static System.Random rand = new System.Random();

    protected List<GameObject> moves;
    protected CombatCharacter character;
    protected CombatController controller;

    void Start()
    {
        currentAction = null;
        controller = GameObject.FindGameObjectWithTag("CombatController").GetComponent<CombatController>();
        moves = gameObject.GetComponent<CombatCharacter>().moves;
        character = gameObject.GetComponent<CombatCharacter>();
    }

    public override Acao getAction()
    {
        if (!getNextState())
        {
            if (currentAction == null)
            {
                getNextAction();
                return null;
            }

            else if (currentAction.Target.Count == 0)
            {
                getActionTarget();
                return null;
            }

            else if (currentAction.Place == int.MinValue)
            {
                getActionPlace();
                return null;
            }
            else
                return currentAction;
        }
        return null;
    }

    protected abstract void getActionPlace();
    protected abstract void getActionTarget();
    protected abstract void getNextAction();
    public abstract bool getNextState();

}
