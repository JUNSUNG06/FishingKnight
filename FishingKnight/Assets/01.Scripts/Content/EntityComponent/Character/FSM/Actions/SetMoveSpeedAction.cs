using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMoveSpeedAction : FSMAction
{
    [SerializeField] private float moveSpeed;

    public override void EnterState()
    {
        base.EnterState();

        character.Movement.SetMoveSpeed(moveSpeed, false);
        character.Anim.Animator.SetFloat("move_speed", moveSpeed);
    }
}
