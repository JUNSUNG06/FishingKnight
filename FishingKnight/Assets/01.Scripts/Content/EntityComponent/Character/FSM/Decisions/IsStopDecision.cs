using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsStopDecision : FSMDecision
{
    public override void Satisfy()
    {
        result = character.Movement.MoveDirection == Vector3.zero;
    }
}
