using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsStopDecision : FSMDecision
{
    private CharacterMovement movement;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        movement = character.GetEntityComponent<CharacterMovement>();
    }

    public override void Satisfy()
    {
        result = movement.MoveDirection == Vector3.zero;
    }
}
