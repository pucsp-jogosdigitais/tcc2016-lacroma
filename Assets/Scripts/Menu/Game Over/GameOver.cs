using UnityEngine;
using System.Collections;
using System;

public class GameOver : MonoBehaviour {

    Character player;
    Animator anim;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        player.OnHpChange += Die;
        anim = gameObject.GetComponent<Animator>();

    }

    private void gameOver()
    {
        anim.SetTrigger("Enter");
    }

    private void Die(object sender, HpChangeArgs args)
    {
        if (args.Hp <= 0)
            anim.SetTrigger("Enter");
    }

    void animationEnded()
    {
        BroadcastMessage("backgroundEnterEnder", SendMessageOptions.DontRequireReceiver);
    }
}
