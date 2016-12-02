using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayVideo : Response
{

    MovieTexture tex;
    bool played = false;
    

    void Start()
    {
        tex = (MovieTexture)(GetComponent<RawImage>().texture);
        setTriggers();
    }

    protected override void triggerResponse(object sender, EventArgs e)
    {
        tex.Play();
        played = true;
    }

    void Update()
    {
        if (!tex.isPlaying && played)
        {
            BroadcastMessage("callTrigger", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
