using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class StandardAttack : AcaoPlace
{
    public override int setPlace()
    {
        int place = selectPlace();

        if (place != int.MinValue)
            controller.standardActions.Insert(place, gameObject.GetComponent<Acao>());
        return place;
    }
}
