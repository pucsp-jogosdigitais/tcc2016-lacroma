using UnityEngine;
using System.Collections;

public class CombatBranchAnimationHandler : MonoBehaviour {

    void selectedMove(bool isSelected)
    {
        AnimateArgs args = new AnimateArgs("Is_Selected_Move");
        args.B = isSelected;
        BroadcastMessage("animateBool", args);
    }

    void expanded(bool isExpanded)
    {
        AnimateArgs args = new AnimateArgs("Is_Enabled");
        args.B = isExpanded;
        BroadcastMessage("animateBool", args);
    }

}
