using UnityEngine;
using System.Collections;

public class SetAnimationState : MonoBehaviour {

	public string stateName;
    public bool once = false;

	void Update () {
        if (!once)
        {
            BroadcastMessage("animateOnce", stateName);
            once = true;
        }
	}

}
