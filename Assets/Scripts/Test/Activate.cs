using UnityEngine;
using System.Collections;

public class Activate : MonoBehaviour {

	private void triggerFunction(){
		gameObject.GetComponent<SpriteRenderer> ().material.SetFloat ("_Sat", 1.0f);
	}

	private void triggerOut(){
		gameObject.GetComponent<SpriteRenderer> ().material.SetFloat ("_Sat", 0.0f);
	}
}
