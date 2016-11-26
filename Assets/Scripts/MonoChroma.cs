using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public abstract class MonoChroma : MonoBehaviour {

    private Collision2D currentCollision;
    private Collider2D currentCollider;
    private bool triggerIn = false;
    private bool collisionIn = false;

    void FixedUpdate()
    {
        if (collisionIn)
            SendMessage("OnCollisionEnterOrStay2D", currentCollision, SendMessageOptions.DontRequireReceiver);

        if (triggerIn)
            OnTriggerEnterOrStay2D(currentCollider);

    }

	void OnCollisionEnter2D (Collision2D other){

		foreach (ContactPoint2D c in other.contacts) {
			if (Math.Abs(((Vector2)gameObject.transform.position - c.point).normalized.y - 1) < 0.03)
				SendMessage ("BottomCollision", other, SendMessageOptions.DontRequireReceiver);
		}
        SendMessage("OnCollisionEnterOrStay2D", other, SendMessageOptions.DontRequireReceiver);
        collisionIn = true;
        currentCollision = other;
	}

    void OnCollisionExit2D()
    {
        collisionIn = false;
        currentCollision = null;
    }

    public virtual void OnTriggerEnterOrStay2D(Collider2D other) { }

    void OnTriggerEnter2D(Collider2D other)
    {
        OnTriggerEnterOrStay2D(other);
        triggerIn = true;
        currentCollider = other;
    }

    void OnTriggerExit2D()
    {
        triggerIn = false;
        currentCollider = null;
    }
}
