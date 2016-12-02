using UnityEngine;
using System.Collections;
using System;

public class AnimateScript : MonoBehaviour {

	private Animator anim;

	void Start(){
		anim = gameObject.GetComponent<Animator> ();
	}

	void animateStart (string animation){
		anim.SetBool(animation, true);
	}

	void animateStop (string animation){
		anim.SetBool(animation, false);
	}

	void animateOnce (string animation){
		anim.SetTrigger(animation);
	}

    void animateOnce(AnimateArgs args)
    {
        anim.SetTrigger(args.AnimationName);
    }

    void animateFloat(AnimateArgs args){
		anim.SetFloat (args.AnimationName, args.F);
	}

	void animateInt(AnimateArgs args){
		anim.SetInteger (args.AnimationName, args.I);
	}

    void animateBool (AnimateArgs args)
    {
        anim.SetBool(args.AnimationName, args.B);
    }
}
