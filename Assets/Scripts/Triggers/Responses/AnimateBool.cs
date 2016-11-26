using UnityEngine;
using System.Collections;
using System;

public class AnimateBool : Response {
    
    //Prefira o uso de Animate

	private Animator anim;
	public string animationEnter;

	void Start(){
		anim = gameObject.GetComponent<Animator> ();
        setTriggers();
	}

    protected override void triggerResponse(object sender, EventArgs e)
    {
		anim.SetBool(animationEnter, true);
	}

    protected override void leaveResponse(object sender, EventArgs e)
    {
        anim.SetBool(animationEnter, false);
    }
}
