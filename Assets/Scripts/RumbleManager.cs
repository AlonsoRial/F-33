using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RumbleManager : MonoBehaviour
{
    public static RumbleManager instance;

    private Gamepad pad;

    private Coroutine stoRumbleAfterTimeCoroutine;

    public Toggle toggle3;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        toggle3 = instance.toggle3;

    }


    public void RumblePulse(float lowFrequency, float highFrequency, float duration)
    {
        if (toggle3.isOn)
        {

            pad = Gamepad.current;

            if (pad != null)
            {
                pad.SetMotorSpeeds(lowFrequency, highFrequency);

                stoRumbleAfterTimeCoroutine = StartCoroutine(StopRumble(duration, pad));
            }
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
