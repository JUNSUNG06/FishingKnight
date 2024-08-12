using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class InteractAction : FSMAction
{
    [SerializeField] private PlayInputSO input;

    public override void EnterState()
    {
        base.EnterState();

        input.RegistAction(PlayInputActionType.Interact, Interact);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        character.Interact.FindObject();
    }

    public override void ExitState()
    {
        base.ExitState();

        input.UnregistAction(PlayInputActionType.Interact, Interact);
    }

    private void Interact(CallbackContext context)
    {
        if (context.started)
            character.Interact.Interact();
    }
}