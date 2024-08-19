using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEndDecision : FSMDecision
{
    private bool isEnd;

    private EntityAnimation anim;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        anim = character.GetEntityComponent<EntityAnimation>();
    }

    public override void EnterState()
    {
        base.EnterState();

        isEnd = false;
        anim.Event.RegistEvent(AnimationEventType.End, onAnimationEnd);
    }

    public override void Satisfy()
    {
        result = isEnd;
    }

    public override void ExitState()
    {
        base.ExitState();

        anim.Event.UnregistEvent(AnimationEventType.End, onAnimationEnd);
    }

    private void onAnimationEnd()
    {
        isEnd = true;
    }
}
