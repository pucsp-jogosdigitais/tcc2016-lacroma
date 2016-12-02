using UnityEngine;
using System.Collections;

public class GrayController : ColorController {

    protected override void newColorValue(object sender, ColorChangeEventArgs args)
    {
        base.OnColorChange(new ColorChangeEventArgs(0));
    }

}
