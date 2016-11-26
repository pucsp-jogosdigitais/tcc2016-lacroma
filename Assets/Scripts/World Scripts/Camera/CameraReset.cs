using UnityEngine;
using System.Collections;

public class CameraReset : MonoBehaviour {

    private Vector3 velocity = Vector3.zero;
    public float CAMERA_DELAY = 1.3f;

    void FixedUpdate ()
    {
        Vector3 offset = new Vector3(0, 0, -10) - gameObject.transform.localPosition;
        Camera.main.transform.localPosition = Vector3.SmoothDamp(Camera.main.transform.localPosition, offset, ref velocity, CAMERA_DELAY);
    }
}
