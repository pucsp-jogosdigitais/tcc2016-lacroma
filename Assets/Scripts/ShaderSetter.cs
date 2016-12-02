using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShaderSetter : MonoBehaviour {

    List<SpriteRenderer> model;
    public Shader shader;

    public void setSaturation(float sat)
    {
        if(model == null)
        {
            model = getAllRenderers(gameObject.transform);
            foreach (SpriteRenderer rend in model)
                rend.material = new Material(shader);
        }
        foreach (SpriteRenderer renderer in model)
        {
            Material mat = renderer.material;
            mat.SetFloat("_Sat", sat);
        }
    }

    private List<SpriteRenderer> getAllRenderers(Transform obj)
    {
        List<SpriteRenderer> result = new List<SpriteRenderer>();
        if (obj.GetComponent<SpriteRenderer>())
            result.Add(obj.GetComponent<SpriteRenderer>());

        foreach (Transform child in obj.transform)
            result.AddRange(getAllRenderers(child));

        return result;
    }
}
