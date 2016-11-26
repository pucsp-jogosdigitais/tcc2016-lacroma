using UnityEngine;
using System.Collections;

public class TextoMenuAnimationHandler : MonoBehaviour {

    void backgroundEnterEnder()
    {
        SendMessage("animateOnce", "Enter");
    }

}
