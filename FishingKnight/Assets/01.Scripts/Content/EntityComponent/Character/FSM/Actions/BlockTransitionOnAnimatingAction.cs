using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTransitionOnAnimatingAction : FSMAction
{
    public override void EnterState()
    {
        base.EnterState();

        character.Anim.Event.RegistEvent(AnimationEventType.Start, BlockTransition);
        character.Anim.Event.RegistEvent(AnimationEventType.End, UnblockTransition);
    }

    public override void ExitState()
    {
        base.ExitState();

        character.Anim.Event.UnregistEvent(AnimationEventType.Start, BlockTransition);
        character.Anim.Event.UnregistEvent(AnimationEventType.End, UnblockTransition);
    }

    private void BlockTransition()
    {
        character.FSM.CanTransition = false;
    }

    private void UnblockTransition()
    {
        character.FSM.CanTransition = true;
    }
}
