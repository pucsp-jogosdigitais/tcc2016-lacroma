using UnityEngine;
using System;

public class CollisionTrigger : Trigger {

    public string tagName = "";


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (tagName == "" || coll.collider.tag == tagName)
        {
            base.triggerFire(new EventArgs());
        }
    }

    void OnCollisionExit2D()
    {
        base.triggerLeave(new EventArgs());
    }
}
