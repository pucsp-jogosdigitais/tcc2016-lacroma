using UnityEngine;
using System.Collections;

public class setSaturation : MonoBehaviour {

    public float sat;

    void Start()
    {
        BroadcastMessage("setSaturation", sat);
    }



}
