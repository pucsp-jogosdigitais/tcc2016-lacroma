using UnityEngine;
using System.Collections;
using System;

public class BlueController : ColorController {
	protected override void newColorValue(object sender, ColorChangeEventArgs args){
		base.OnColorChange (new ColorChangeEventArgs ((-1 * Math.Sin(args.Color * Mathf.Deg2Rad) + 1) / 2));
	}
}