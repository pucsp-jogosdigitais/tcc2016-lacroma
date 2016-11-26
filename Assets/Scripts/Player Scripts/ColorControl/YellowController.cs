using UnityEngine;
using System.Collections;
using System;

public class YellowController : ColorController {
	protected override void newColorValue(object sender, ColorChangeEventArgs args){
		base.OnColorChange (new ColorChangeEventArgs ((Math.Sin(args.Color * Mathf.Deg2Rad) + 1) / 2));
	}
}