using UnityEngine;
using System.Collections;

public class GameOverSecao : MonoBehaviour {

    void selected(bool isSelected)
    {
        AnimateArgs args = new AnimateArgs("IsSelected");
        args.B = isSelected;
        BroadcastMessage("animateBool", args);
    }
}
