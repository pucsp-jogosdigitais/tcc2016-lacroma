using UnityEngine;
using System.Collections;

public class MenuSectionAnimationHandler : MonoBehaviour {

    private Pause pauseController;

    void Start()
    {
        pauseController = GameObject.FindWithTag("WorldController").GetComponent<Pause>();
        pauseController.OnPause += menuLeave;
    }

    void backgroundEnterEnded()
    {
        SendMessage("animateStart", "Section_Ativa");
    }

    void menuLeave(object sender, PauseEventArgs args)
    {
        SendMessage("animateStop", "Section_Ativa");
    }

    void selected(bool isSelected)
    {
        AnimateArgs args = new AnimateArgs("Is_Selected");
        args.B = isSelected;
        BroadcastMessage("animateBool", args);
    }

    void expanded(bool isExpandade)
    {
        AnimateArgs args = new AnimateArgs("Is_Expanded");
        args.B = isExpandade;
        BroadcastMessage("animateBool", args);
    }
}
