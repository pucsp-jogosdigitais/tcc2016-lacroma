using UnityEngine;
using System.Collections;
using System;

public class PlaySound : Response
{

    AudioSource sound;

    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
        setTriggers();
    }

    protected override void triggerResponse(object sender, EventArgs args)
    {
        if (!sound.isPlaying)
            sound.Play();
    }
}
