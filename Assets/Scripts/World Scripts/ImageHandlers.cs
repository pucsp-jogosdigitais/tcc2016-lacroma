using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageHandlers : MonoBehaviour {

    bool imageShown = false;
    bool buttonDown;
    Canvas canvas;

	void Start () {
       canvas = gameObject.GetComponent<Canvas>();
	}

    void displayImage()
    {
        gameObject.GetComponent<Canvas>().enabled = true;
        buttonDown = true;
        imageShown = true;
    }

    void Update()
    {
        if (!buttonDown && imageShown && (Input.GetButtonDown("Interact") || Input.GetButtonDown("Jump")))
        {
            canvas.enabled = false;
            imageShown = false;
            Time.timeScale = 1;
        }
        if (buttonDown)
            buttonDown = false;
    }
	
}
