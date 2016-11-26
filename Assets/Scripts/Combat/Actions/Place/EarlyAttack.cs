using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class EarlyAttack : AcaoPlace
{
    public override int setPlace()
    {
        controller.earlyActions.Insert(0, gameObject.GetComponent<Acao>());
        return -1;
    }
}
