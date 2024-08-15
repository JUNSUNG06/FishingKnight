using OMG.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu (menuName = "SO/Play")]
public class PlayInputSO : InputSO<PlayInputActionType>, IPlayActions
{
    protected override void OnEnable()
    {
        base.OnEnable();

        PlayActions play = InputManager.controls.Play;
        play.SetCallbacks(this);
        InputManager.RegistInputMap(this, play.Get());
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputActions[PlayInputActionType.Move]?.Invoke(context);
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        inputActions[PlayInputActionType.Run]?.Invoke(context);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        inputActions[PlayInputActionType.Interact]?.Invoke(context);
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        inputActions[PlayInputActionType.Cancel]?.Invoke(context);
    }

    public void OnOpenInventory(InputAction.CallbackContext context)
    {
        inputActions[PlayInputActionType.OpenInventory]?.Invoke(context);
    }
}