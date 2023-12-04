using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Rumbler : MonoBehaviour
{
    private PlayerInput _playerInput;

    Gamepad[] game = new Gamepad[2];
    private float rumbleDurration;
    private float lowA = 0.3f;
    private float highA =0.8f;

    bool run;

    public Joystick joystick;

    
    public void StopRumble()
    {
        
        var gamepad1 = game[0];
        var gamepad2 = game[1];

        if (gamepad1 != null)
        {
            gamepad1.SetMotorSpeeds(0, 0);
        }

        if (gamepad2 != null)
        {
            gamepad2.SetMotorSpeeds(0, 0);
        }

    }


    // Unity MonoBehaviors
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        GetGamepad();

        var gamepad1 = game[0];
        var gamepad2 = game[1];

        
        if (gamepad1 == null) { return; }
        if (gamepad2 == null) { return; }

       if (gamepad1.rightTrigger.isPressed)
        {
  
            gamepad1.SetMotorSpeeds(lowA, highA);

        }
        else if(gamepad2.IsPressed()) {
            
            gamepad2.SetMotorSpeeds(lowA, highA);
        }
        else
        {
            StopRumble();
        }


    }


 

    private void OnDestroy()
    {
        StopAllCoroutines();
        StopRumble();
    }

    // Private helpers

    public void  GetGamepad()
    {
        
        game[0]=  Gamepad.all.FirstOrDefault(g => _playerInput.devices.Any(d => d.deviceId == g.deviceId));

       //joystick = Joystick.all.FirstOrDefault(i => _playerInput.devices.Any(d=> d.deviceId == d.deviceId));

       game[1] =Gamepad.all.LastOrDefault(g => _playerInput.devices.Any(d => d.deviceId == g.deviceId));
       
    }
}