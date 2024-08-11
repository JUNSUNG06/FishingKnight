using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRootMotionAction : FSMAction
{
    public override void EnterState()
    {
        base.EnterState();

        character.Anim.SetRootMotion(true);
    }

    public override void ExitState()
    {
        base.ExitState();

        character.Anim.SetRootMotion(false);
    }
}
