using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class SetMoveDirectionByInputAction : FSMAction
{
    [SerializeField] private PlayInputSO input;

    [Space]
    [SerializeField] private bool withCameraForward = true;

    private CharacterMovement movement;

    public override void Initialize(Character character)
    {
        base.Initialize(character);
        
        movement = character.GetEntityComponent<CharacterMovement>();
    }

    public override void EnterState()
    {
        base.EnterState();

        input.RegistAction(PlayInputActionType.Move, SetMoveDir);
    }

    public override void ExitState()
    {
        base.ExitState();

        input.UnregistAction(PlayInputActionType.Move, SetMoveDir);
    }

    private void SetMoveDir(CallbackContext context)
    {
        if(context.performed || context.canceled)
        {
            Vector2 input = context.ReadValue<Vector2>();
            Vector3 moveDir = new Vector3(input.x, 0, input.y);
            if (withCameraForward)
                moveDir = Manager.Instance.Camera.CameraForward * moveDir;
            movement.SetMoveDirection(moveDir);
        }
    }
}
