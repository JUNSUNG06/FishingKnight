using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : FSMAction
{
    public override void UpdateState()
    {
        base.UpdateState();

        owner.Movement.Move();
    }
}
