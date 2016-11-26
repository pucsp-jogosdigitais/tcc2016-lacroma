using UnityEngine;
using System.Collections;
using System;

public abstract class CombatCharacterController : MonoBehaviour {

    protected Acao currentAction;

    public abstract Acao getAction();

    public virtual void resetAction()
    {
        currentAction = null;
    }

}
