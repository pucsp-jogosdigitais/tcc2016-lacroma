using UnityEngine;
using System.Collections;

public class IrisAnimationHandler : MonoBehaviour {

	void isMoving(float speed){
		AnimateArgs args = new AnimateArgs ("MovingGround");
		args.F = speed;
		SendMessage ("animateFloat", args);
	}


	void saturationChange(float sat){
		AnimateArgs args = new AnimateArgs ("saturationChange");
		args.F = sat;
		SendMessage ("animateFloat", args);
	}

    void startJumping(){
        SendMessage("animateOnce", "Jump");
    }

    void verticalSpeed(float speed)
    {
        AnimateArgs args = new AnimateArgs("velocityJump");
        args.F = speed;
        SendMessage("animateFloat", args);
    }

    void isGrounded()
    {
        SendMessage("animateStart", "IsGrounded");
    }

    void notGrounded()
    {
        SendMessage("animateStop", "IsGrounded");
    }

    void animateHurt()
    {
        SendMessage("animateOnce", "Hurt");
    }

    void die()
    {
        SendMessage("animateOnce", "Die");
    }

}