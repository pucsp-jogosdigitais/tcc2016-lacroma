using UnityEngine;
using System.Collections;
using System;

public class StopMusic : Response {

    public bool destroy = false;

    protected override void triggerResponse(object sender, EventArgs e)
    {
        if (!destroy)
            GameObject.Find("Musica").GetComponent<AudioSource>().Pause();
        else
            Destroy(GameObject.Find("Musica"));
    }
}
