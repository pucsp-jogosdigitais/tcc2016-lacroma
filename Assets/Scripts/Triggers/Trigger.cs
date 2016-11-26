using UnityEngine;
using System;

public abstract class Trigger : MonoChroma {

    public event EventHandler<EventArgs> OnTrigger;
    public event EventHandler<EventArgs> OnLeave;

    protected virtual void triggerFire(EventArgs args)
    {
        if(OnTrigger != null)
            OnTrigger(this, args);
    }

    protected virtual void triggerLeave(EventArgs args)
    {
        if(OnLeave != null)
            OnLeave(this, args);
    }

}
