using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class InteractAction : FSMAction
{
    [SerializeField] private PlayInputSO input;

    private CharacterInteract interact;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        interact = character.GetEntityComponent<CharacterInteract>();
    }

    public override void EnterState()
    {
        base.EnterState();

        input.RegistAction(PlayInputActionType.Interact, Interact);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        interact.FindObject();
    }

    public override void ExitState()
    {
        base.ExitState();

        input.UnregistAction(PlayInputActionType.Interact, Interact);
    }

    private void Interact(CallbackContext context)
    {
        if (context.started)
            interact.Interact();
    }
}