using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class teste : MonoBehaviour {

    void Start()
    {
        ((MovieTexture)(GetComponent<RawImage>().texture)).loop = true;
        ((MovieTexture)(GetComponent<RawImage>().texture)).Play();
    }
}
