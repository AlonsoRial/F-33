using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RumbleManager : MonoBehaviour
{
    public static RumbleManager instance;

    private Gamepad pad;

    private Coroutine stoRumbleAfterTimeCoroutine;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }


    }


    public void RumblePulse(float lowFrequency, float highFrequency, float duration) 
    {
        pad = Gamepad.current;

        if (pad != null) {
            pad.SetMotorSpeeds(lowFrequency, highFrequency);

            stoRumbleAfterTimeCoroutine = StartCoroutine(StopRumble(duration, pad)); 
        }
    }


    private IEnumerator StopRumble(float duration, Gamepad pad)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        pad.SetMotorSpeeds(0f, 0f);
    }
}
