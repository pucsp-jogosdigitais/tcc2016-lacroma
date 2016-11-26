using UnityEngine;
using System.Collections;

public class MenuAnimationHandler : MonoBehaviour {

    private Pause pauseController;
    private Animator anim;

    void Start(){
        pauseController = GameObject.FindWithTag("WorldController").GetComponent<Pause>();
        pauseController.OnPause += animatePause;
        anim = gameObject.GetComponent<Animator>();
    }

    void animatePause(object sender, PauseEventArgs args)
    {
        anim.SetBool("Menu_Active", args.IsPaused);
    }

    void animationEnded()
    {
        BroadcastMessage("menuEnterEnded");
    }

}
