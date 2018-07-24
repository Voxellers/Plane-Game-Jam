using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    public float duration = 0.25f;
    public float speed = 1.0f;
    public float magnitude = 0.1f;

    public IEnumerator Shake()
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;

            // We want to reduce the shake from full power to 0 starting half way through
            float damper = 1.0f - Mathf.Clamp(2.0f * percentComplete - 1.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float z = Random.value * 2.0f - 1.0f;

            x *= magnitude * damper;
            z *= magnitude * damper;

            transform.position += new Vector3(0, 0, z);

            yield return null;
        }
    }
}
