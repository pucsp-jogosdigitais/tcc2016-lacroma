using UnityEngine;
using System.Collections;
using System;

public class Damager : MonoBehaviour {

	public int damage = 1;

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.collider.gameObject.tag == "Player") {
			coll.collider.gameObject.BroadcastMessage ("onHurt", new DamageArgs(coll, damage), SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnCollisionStay2D(Collision2D coll){
		if (coll.collider.gameObject.tag == "Player") {
			coll.collider.gameObject.BroadcastMessage ("onHurt", new DamageArgs(coll, damage), SendMessageOptions.DontRequireReceiver);
		}
	}

}

public class DamageArgs : EventArgs{
	Collision2D collision;
	int damage;

	public Collision2D Collision{
		get { return collision; }
	}

	public int Damage{
		get { return damage; }
	}

	public DamageArgs(Collision2D coll, int dam){
		collision = coll;
		damage = dam;
	}	
}
