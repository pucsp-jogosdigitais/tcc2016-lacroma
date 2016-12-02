using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public Animator animator;
   
	
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButton("Fire1"))
        {
            animator.SetTrigger("Attack");
        }
	
	}
}
