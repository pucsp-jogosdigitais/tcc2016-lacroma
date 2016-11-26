using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MaterialController : MonoBehaviour {

    public float saturation;
    public Color color = Color.white;
    Material material;

    void Start()
    {
        material = gameObject.GetComponent<Image>().material;
    }

    void Update()
    {
        material.SetColor("_Color", color);
        material.SetFloat("_Sat", saturation);
    }

}
