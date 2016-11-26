using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class LateAttack : AcaoPlace
{
    public override int setPlace()
    {
        controller.lateActions.Add(gameObject.GetComponent<Acao>());
        return int.MaxValue;
    }
}
