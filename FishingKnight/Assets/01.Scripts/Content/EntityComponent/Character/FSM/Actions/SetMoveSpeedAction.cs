using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMoveSpeedAction : FSMAction
{
    [SerializeField] private float moveSpeed;

    private CharacterMovement movement;
    private EntityAnimation anim;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        movement = character.GetEntityComponent<CharacterMovement>();
        anim = character.GetEntityComponent<EntityAnimation>();
    }

    public override void EnterState()
    {
        base.EnterState();

        movement.SetMoveSpeed(moveSpeed, false);
        anim.Animator.SetFloat("move_speed", moveSpeed);
    }
}
