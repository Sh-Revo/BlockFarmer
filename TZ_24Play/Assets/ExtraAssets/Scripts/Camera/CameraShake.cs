using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }
    
    private float _shakeRange = 0.5f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-_shakeRange, _shakeRange) * magnitude;
            float y = Random.Range(-_shakeRange, _shakeRange) * magnitude;

            transform.localPosition = new Vector3 (x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
