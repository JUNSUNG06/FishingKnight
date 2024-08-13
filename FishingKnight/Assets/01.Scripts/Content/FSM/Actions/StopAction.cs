using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAction : FSMAction
{
    public override void EnterState()
    {
        base.EnterState();

        character.Movement.Stop();
        character.Anim.Animator.SetFloat("move_speed", 0f);
    }
}
