using System.Collections;
using UnityEngine;

public sealed class GameCamera : MonoBehaviour
{
    public static GameCamera instance = null;

    public Camera myCamera;
    public float singleShakeDurationInSeconds = 0.1f;

    private float shakeStrength = 0.0f;
    private int shakesLeft = 0;
    private float shakeDeadline = 0.0f;

    private void Awake()
    {
        instance = this;
    }

    public void Shake(float strength, int shakeCount)
    {
        if (strength > shakeStrength)
        {
            shakeStrength = strength;
            shakesLeft = shakeCount;
            shakeDeadline = 0.0f;
        }
    }

    private void Update()
    {
        if (shakesLeft == 0)
        {
            return;
        }

        var time = Time.time;
        if (time > shakeDeadline)
        {
            shakesLeft -= 1;
            if (shakesLeft == 0)
            {
                myCamera.transform.localPosition = Vector3.zero;
                shakeStrength = 0.0f;
            }
            else
            {
                myCamera.transform.localPosition = Random.insideUnitCircle.normalized * shakeStrength;
                shakeDeadline = time + singleShakeDurationInSeconds;
            }
        }
    }
}
