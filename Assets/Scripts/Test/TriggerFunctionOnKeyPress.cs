using UnityEngine;
using System.Collections;

public class TriggerFunctionOnKeyPress : MonoBehaviour {

    public string function;
    public KeyCode code;

    void Update()
    {
        if (Input.GetKeyDown(code))
        {
            SendMessage(function);
        }
    }

}
