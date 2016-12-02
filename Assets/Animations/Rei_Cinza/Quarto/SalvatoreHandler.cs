using UnityEngine;
using System.Collections;

public class SalvatoreHandler : MonoBehaviour {

    public void animateGetUp()
    {
        BroadcastMessage("animateOnce", "getUp");
    }

}
