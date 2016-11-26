using UnityEngine;
using System.Collections;
using System;

public class FadeToGray : MonoBehaviour {

    Character player;
    Animator anim;

    void Start () {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        player.OnHpChange += Die;
        anim = gameObject.GetComponent<Animator>();
	
	}

    private void Die(object sender, HpChangeArgs args)
    {
        if (args.Hp <= 0)
            anim.SetTrigger("Die");
    }

    private void fade()
    {
        anim.SetTrigger("Die");
    }
}
