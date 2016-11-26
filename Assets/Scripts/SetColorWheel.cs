using UnityEngine;
using System.Collections;
using System;

public class SetColorWheel : MonoBehaviour {

    private float redValue;
    private float blueValue;

    private ColorController red;
    private ColorController blue;
    public double correction = 135.0f;

    void Start()
    {
        red = GameObject.FindWithTag("RedController").GetComponent<ColorController>();
        blue = GameObject.FindWithTag("BlueController").GetComponent<ColorController>();
        red.ColorChange += setRed;
        blue.ColorChange += setBlue;
    }

    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, getAngle());
    }

    private float getAngle()
    {
        return (float)(Mathf.Rad2Deg * Math.Atan2(redValue, blueValue) + correction);
    }

    private void setRed(object sender, ColorChangeEventArgs args)
    {
        redValue = ((float)args.Color) * 2 - 1;
    }

    private void setBlue(object sender, ColorChangeEventArgs args)
    {
        blueValue = ((float)args.Color) * 2 - 1;
    }

}
