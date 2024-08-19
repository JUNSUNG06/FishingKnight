using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTransitionOnAnimatingAction : FSMAction
{
    private EntityAnimation anim;
    private CharacterFSM fsm;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        anim = character.GetEntityComponent<EntityAnimation>();
        fsm = character.GetEntityComponent<CharacterFSM>();
    }

    public override void EnterState()
    {
        base.EnterState();

        anim.Event.RegistEvent(AnimationEventType.Start, BlockTransition);
        anim.Event.RegistEvent(AnimationEventType.End, UnblockTransition);
    }

    public override void ExitState()
    {
        base.ExitState();

        anim.Event.UnregistEvent(AnimationEventType.Start, BlockTransition);
        anim.Event.UnregistEvent(AnimationEventType.End, UnblockTransition);
    }

    private void BlockTransition()
    {
        fsm.CanTransition = false;
    }

    private void UnblockTransition()
    {
        fsm.CanTransition = true;
    }
}
