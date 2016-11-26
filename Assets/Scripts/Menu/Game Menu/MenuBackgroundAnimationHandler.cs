using UnityEngine;
using System.Collections;

public class MenuBackgroundAnimationHandler : MonoBehaviour {

    private Pause pauseController;

    void Start()
    {
        pauseController = GameObject.FindWithTag("WorldController").GetComponent<Pause>();
        pauseController.OnPause += menuLeave;
    }

    void menuEnterEnded()
    {
        SendMessage("animateStart", "Menu_Ativo");
    }

    void menuLeave(object sender, PauseEventArgs args)
    {
        SendMessage("animateStop", "Menu_Ativo");
    }

    void animationEnded()
    {
        BroadcastMessage("backgroundEnterEnded");
    }

}
