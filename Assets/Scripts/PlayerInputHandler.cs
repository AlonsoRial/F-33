using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private float lowA = 0.3f;
    private float highA = 0.8f;
    private Gamepad gamepad;
    private PlayerInput playerInput;
    private Mover mover;

    public static bool vibra = true;

    private void Awake()
    {
        Cursor.visible = false;
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

    private void GameIni()
    {
        gamepad = Gamepad.all.SingleOrDefault(g => playerInput.devices.Any(d => d.deviceId == g.deviceId));
    }

    public void StopRumble()
    {
        var gamepad1 = gamepad;

        if (gamepad1 != null)
        {
            gamepad1.SetMotorSpeeds(0, 0);
        }

    }


    private void OnDestroy()
    {
        StopAllCoroutines();
        StopRumble();
    }


    private void Update()
    {
        GameIni();

        var gamepad1 = gamepad;



        if (gamepad1 == null) { return; }


        if (gamepad1.rightTrigger.isPressed)
        {
            
            if (vibra ==true && mover.pasarTempo)
            {
               // Debug.Log("YES");
                gamepad1.SetMotorSpeeds(lowA, highA);
            }
            else
            {
               // Debug.Log("NO");
            }

            

        }
        else
        {
            StopRumble();
        }
    }

    public void Changed(bool change)
    {
      //  Debug.Log("CHANGE " + change);
        vibra = change;
    }

}