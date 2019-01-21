using UnityEngine;
using System.Collections;

public class CameraShaker : MonoBehaviour
{
    private Transform camTransform;

    private float shakeDuration = 0f;

    //larger value shakes the camera harder
    private float shakeAmplitude = 0.7f;
    private float decreaseFactor = 1.0f;

    private bool earthquake = false;
    private bool earthquakeStart = false;

    Vector3 originalPos;

    void Awake()
    {
        camTransform = GetComponent<Transform>() as Transform;
    }

    void Start()
    {
        originalPos = camTransform.localPosition;
    }

    public void StartEarthquake()
    {
        earthquake = true;
        shakeDuration = 1f;
    }

    void Update()
    {
        if (earthquake)
        {
            if (shakeDuration > 0)
            {
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmplitude;

                shakeDuration -= Time.deltaTime * decreaseFactor;
            }

            //set back to normal
            else
            {
                shakeDuration = 0f;
                earthquake = false;
                camTransform.localPosition = originalPos;
            }
        }
    }
}