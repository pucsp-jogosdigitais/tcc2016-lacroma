using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DisplayImage : Response {

    public Sprite image;

    protected override void triggerResponse(object sender, EventArgs args)
    {
        GameObject.Find("DisplayImage").GetComponent<Image>().sprite = image;
        GameObject.Find("ImageCanvas").BroadcastMessage("displayImage");

        Time.timeScale = 0;
    }

}
