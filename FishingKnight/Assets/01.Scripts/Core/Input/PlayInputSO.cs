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
}