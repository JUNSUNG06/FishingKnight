using OMG.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Controls;

[CreateAssetMenu(menuName = "SO/UI")]
public class UIInputSO : InputSO<UIInputActionType>, IUIActions
{
    protected override void OnEnable()
    {
        base.OnEnable();

        UIActions ui = InputManager.controls.UI;
        ui.SetCallbacks(this);
        InputManager.RegistInputMap(this, ui.Get());
    }

    public void OnBack(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        inputActions[UIInputActionType.Back]?.Invoke(context);
    }
}
