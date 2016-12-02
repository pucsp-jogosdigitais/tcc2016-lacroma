using UnityEngine;
using System.Collections;

public class CombatAnimationHandler : MonoBehaviour {

    Acao hitBy;

    private void animateAttack(string name)
    {
        if (name == "")
            SendMessage("animateOnce", "Attack");
        else
            SendMessage("animateOnce", name);
    }

    private void animateHit()
    {
        gameObject.transform.parent.gameObject.BroadcastMessage("hit");
    }

    private void damaged(Acao sender)
    {
        hitBy = sender;
        SendMessage("animateOnce", "Damage");
    }

    private void noDamage()
    {
        gameObject.transform.parent.gameObject.BroadcastMessage("end");
        gameObject.transform.parent.gameObject.BroadcastMessage("setSaturation");
    }

    private void damageEnd()
    {
        hitBy.targetHit();
    }

    private void currentLife(float lifePercentage)
    {
        AnimateArgs args = new AnimateArgs("Life");
        args.F = lifePercentage;
        SendMessage("animateFloat", args);
    }
}
