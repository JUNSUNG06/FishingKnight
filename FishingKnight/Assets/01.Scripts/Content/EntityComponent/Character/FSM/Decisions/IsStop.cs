using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsStop : FSMDecision
{
    public override bool IsSatisfy()
    {
        result = owner.Movement.MoveDirection == Vector3.zero;

        return base.IsSatisfy();
    }
}
