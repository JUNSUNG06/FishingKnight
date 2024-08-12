using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnlyMotionAction : FSMAction
{
    public override void EnterState()
    {
        base.EnterState();

        character.Collider.enabled = false;
        character.Movement.EnableGravity(false);
        character.Movement.Stop();
    }

    public override void ExitState()
    {
        base.ExitState();

        character.Collider.enabled = true;
        character.Movement.EnableGravity(true);
        character.Movement.Stop();
    }
}
