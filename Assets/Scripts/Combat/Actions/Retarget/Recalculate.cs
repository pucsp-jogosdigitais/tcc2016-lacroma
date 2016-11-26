using UnityEngine;
using System.Collections;

public class Recalculate : ActionRetarget
{
    public override void retarget(Acao acao)
    {
        gameObject.GetComponent<AcaoTargets>().resetTargets();
    }
}
