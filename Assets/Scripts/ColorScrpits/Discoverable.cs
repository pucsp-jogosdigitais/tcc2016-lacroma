using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Discoverable : MonoBehaviour {

	private float transparence;

    public GameObject[] targets;
	private ColorController green;
	private GameObject discoverer;
	public bool reveal = true; //false para revelar, true para descobrir
	public float startDiscoverDistance = 7.0f;
	public float totalDiscoverDistance = 2.0f;
    List<SpriteRenderer> renderers = new List<SpriteRenderer>();

	void Start(){
        if (targets.Length == 0)
        {
            targets = new GameObject[1];
            targets[0] = gameObject;
        }
		discoverer = GameObject.FindWithTag ("Player");
		green = GameObject.FindWithTag ("GreenController").GetComponent<ColorController> ();
		green.ColorChange += setTransparence;
        transparence = 0f;
        foreach(GameObject obj in targets)
        {
            SpriteRenderer r = obj.GetComponent<SpriteRenderer>();
            renderers.Add(r);
            if (reveal)
                r.material.SetColor("_Color", new Color(1, 1, 1, 0));
            else
                r.material.SetColor("_Color", new Color(1, 1, 1, 1));
        }
    }

	void setTransparence (object sender, ColorChangeEventArgs args)
	{
		float distance = Vector3.Distance (gameObject.transform.position, discoverer.transform.position);
		transparence = (float)args.Color;

        if (distance < startDiscoverDistance && distance > totalDiscoverDistance)
        {
            float adjust = ((startDiscoverDistance - distance) / (startDiscoverDistance - totalDiscoverDistance));

            if (reveal)
                foreach (SpriteRenderer rend in renderers)
                    rend.material.SetColor("_Color", new Color(1f, 1f, 1f, adjust * (float)Math.Pow(transparence, 3)));
            else
                foreach (SpriteRenderer rend in renderers)
                    rend.material.SetColor("_Color", new Color(1f, 1f, 1f, 1 - (adjust * (float)Math.Pow(transparence, 3))));
        }
        else if (distance < totalDiscoverDistance)
        {
            if (reveal)
                foreach (SpriteRenderer rend in renderers)
                    rend.material.SetColor("_Color", new Color(1f, 1f, 1f, (float)Math.Pow(transparence, 3)));
            else
                foreach (SpriteRenderer rend in renderers)
                    rend.material.SetColor("_Color", new Color(1f, 1f, 1f, 1 - (float)Math.Pow(transparence, 3)));
        }
    }

	void OnDestroy(){
		green.ColorChange -= setTransparence;
	}
}
