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
    private void Awake()
    {
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

    public void OnRumber(CallbackContext context) {
        mover.SetRumber(context.ReadValueAsButton());
    }


}