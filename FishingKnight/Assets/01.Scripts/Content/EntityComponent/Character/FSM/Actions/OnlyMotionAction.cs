using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnlyMotionAction : FSMAction
{
    private Collider characterCol;
    private CharacterMovement movement;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        characterCol = character.GetComponent<Collider>();
        movement = character.GetEntityComponent<CharacterMovement>();
    }

    public override void EnterState()
    {
        base.EnterState();

        if(characterCol != null)
            characterCol.enabled = false;
        movement?.EnableGravity(false);
        movement?.Stop();
    }

    public override void ExitState()
    {
        base.ExitState();

        if (characterCol != null)
            characterCol.enabled = true;
        movement?.EnableGravity(true);
        movement?.Stop();
    }
}
