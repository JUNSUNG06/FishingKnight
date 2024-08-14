using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEndDecision : FSMDecision
{
    private bool isEnd;

    public override void EnterState()
    {
        base.EnterState();

        isEnd = false;
        character.Anim.Event.RegistEvent(AnimationEventType.End, onAnimationEnd);
    }

    public override void Satisfy()
    {
        result = isEnd;
    }

    public override void ExitState()
    {
        base.ExitState();

        character.Anim.Event.UnregistEvent(AnimationEventType.End, onAnimationEnd);
    }

    private void onAnimationEnd()
    {
        isEnd = true;
    }
}
