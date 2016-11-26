using UnityEngine;
using System.Collections;
using System;

public class OnHurtOverworld : MonoBehaviour {

    public delegate void OnDamageHandler(object sender, DamageArgs args);
    public event OnDamageHandler OnIsHurt;

    public float recoveryTime = 1.0f;
	public float force = 10.0f;

	private bool isRecovering = false;

	void onHurt (DamageArgs args){
		if (!isRecovering){
            if (OnIsHurt != null)
                OnIsHurt(this, args);
            gameObject.BroadcastMessage("animateHurt");
			isRecovering = true;
			StartCoroutine(StartRecovery(recoveryTime));
			Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D> ();
			rb.AddForce (args.Collision.contacts [0].normal * -force, ForceMode2D.Impulse);
		}
	}

	IEnumerator StartRecovery (float waitTime){
		yield return new WaitForSeconds (waitTime);
		isRecovering = false;

	}

}
