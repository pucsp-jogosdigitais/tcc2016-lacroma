using UnityEngine;
using System.Collections;
using System;

public class RedController : ColorController {
	protected override void newColorValue(object sender, ColorChangeEventArgs args){
		base.OnColorChange( new ColorChangeEventArgs((Math.Cos(args.Color * Mathf.Deg2Rad) + 1)/2));
	}
}
