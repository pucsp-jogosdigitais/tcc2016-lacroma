using UnityEngine;
using System;
using System.Collections;

public class Shake : Response {

    public float duration = 1.0f;
    public float magnitude = 0.5f;

    protected override void triggerResponse(object sender, EventArgs args)
    {
        startShake(duration);
    }

    public void startShake(float duration)
    {
        StartCoroutine(shake(duration));
    }

    IEnumerator shake(float duration)
    {
        float elapsed = 0.0f;

        //Vector3 originalCamPos = Camera.main.transform.localPosition;

        while (elapsed < duration)
        {

            elapsed += Time.unscaledDeltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = UnityEngine.Random.value * 2.0f - 1.0f;
            float y = UnityEngine.Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * 0.5f * damper;

            Camera.main.transform.position += new Vector3(x, y, 0.0f);

            yield return null;
        }
    }
}
