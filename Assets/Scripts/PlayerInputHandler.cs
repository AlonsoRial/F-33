using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Mover mover;

    private Gamepad pad, pad2;

    private Coroutine stoRumbleAfterTimeCoroutine;

    public static PlayerInputHandler instance;

    private void Awake()
    {
        instance = this;
        playerInput = GetComponent<PlayerInput>();
        var movers = FindObjectsOfType<Mover>();
        var index = playerInput.playerIndex;
        mover = movers.FirstOrDefault(m => m.GetPlayerIndex() == index);
    }

    public void OnMove(CallbackContext context)
    {
        if (mover != null)
            mover.SetInputVector(context.ReadValue<Vector2>());
    }

    public void OnRun(CallbackContext context)
    {
        mover.SetInputRun(context.ReadValueAsButton());
    }

    public void OnBack(CallbackContext context)
    {
        mover.SetInputBack(context.ReadValueAsButton());
    }

    public void SwtichCamera(CallbackContext context)
    {
        mover.SetCamera(context.ReadValueAsButton());
    }


    public void RumblePulse(float lowFrequency, float highFrequency, float duration)
    {

        if (pad == null) {
            pad = playerInput.GetDevice<Gamepad>();
        }
        
        if(pad !=null && pad2 == null)
        {
            pad2 = playerInput.GetDevice<Gamepad>();
        }
        
            

            
        pad.SetMotorSpeeds(lowFrequency, highFrequency);

        stoRumbleAfterTimeCoroutine = StartCoroutine(StopRumble(duration, pad));
            

       
        pad2.SetMotorSpeeds(lowFrequency, highFrequency);

        stoRumbleAfterTimeCoroutine = StartCoroutine(StopRumble(duration, pad2));
        

    }

    public void OnRumber(CallbackContext context) {
        mover.SetRumber(context.ReadValueAsButton());
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

