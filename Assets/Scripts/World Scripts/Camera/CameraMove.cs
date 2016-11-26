using UnityEngine;
using System.Collections;
using System;
using System.Security.Cryptography;

public class CameraMove : MonoBehaviour {

	#region constants
	public float Camera_Speed = 1.3f;
	#endregion

	private GameObject target;
	private Vector3 velocity = Vector3.zero;  

	void Start(){
		target = GameObject.FindWithTag ("Player");
	}
	void Update () {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target.transform.position + new Vector3(0, 3, 0), Time.smoothDeltaTime * Camera_Speed);
	}
}
