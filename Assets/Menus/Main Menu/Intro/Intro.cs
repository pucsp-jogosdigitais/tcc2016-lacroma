using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

    void enter()
    {
        GameObject.Find("MainMenu").SendMessage("animateOnce", "Enter");
    }

}
