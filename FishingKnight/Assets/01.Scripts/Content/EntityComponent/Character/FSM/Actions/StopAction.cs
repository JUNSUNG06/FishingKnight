using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAction : FSMAction
{
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

        movement.Stop();
        anim.Animator.SetFloat("move_speed", 0f);
    }
}
