using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class Response : MonoChroma {

    public List<Trigger> triggers;

	void Start () {
        setTriggers();
	}

    protected void setTriggers()
    {
        foreach (Trigger trigger in triggers)
        {
            trigger.OnTrigger += triggerResponse;
            trigger.OnLeave += leaveResponse;
        }
    }

    protected virtual void triggerResponse(object sender, EventArgs e){ }

    protected virtual void leaveResponse(object sender, EventArgs e) { }

    public virtual void addTrigger(Trigger newTrigger)
    {
        newTrigger.OnTrigger += triggerResponse;
        newTrigger.OnLeave += leaveResponse;
        triggers.Add(newTrigger);
    }

    void OnDestroy()
    {
        foreach (Trigger trigger in triggers)
        {
            trigger.OnTrigger -= triggerResponse;
            trigger.OnLeave -= leaveResponse;
        }
    }
}
