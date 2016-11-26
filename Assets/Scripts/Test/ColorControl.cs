using UnityEngine;
using System.Collections;

public class ColorControl : MonoBehaviour {

	public KeyCode minus;
	public KeyCode plus;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float actualSat = gameObject.GetComponent<SpriteRenderer> ().material.GetFloat ("_Sat");
		if (Input.GetKey (plus) && actualSat < 1) {
			gameObject.GetComponent<SpriteRenderer> ().material.SetFloat ("_Sat", actualSat + 0.005f);
		}
		if (Input.GetKey (minus) && actualSat > 0) {
			gameObject.GetComponent<SpriteRenderer> ().material.SetFloat ("_Sat", actualSat - 0.005f);
		}
	}
}
