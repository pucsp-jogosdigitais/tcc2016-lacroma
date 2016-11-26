using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentAxis : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = "Current Vertical: " + Input.GetAxis("Vertical").ToString("F2");
	}
}
