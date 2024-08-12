using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimation : EntityComponent
{
    public Animator Animator { get; private set; }
    public AnimationEvent Event { get; private set; }

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        Animator = owner.transform.Find("Visual").GetComponent<Animator>();
        Event = owner.transform.Find("Visual").GetComponent<AnimationEvent>();

        ResetRootMotion();
    }

    public void SetRootMotion(bool value)
    {
        Animator.applyRootMotion = value;
    }

    public void ResetRootMotion()
    {
        Animator.transform.localPosition = Vector3.zero;
        Animator.transform.localRotation = Quaternion.identity;
    }

    public void AlignToRootMotion()
    {
        if (Animator.transform.localPosition == Vector3.zero)
            return;

        Vector3 pos = Animator.transform.localPosition + entity.transform.localPosition;
        pos.y = entity.transform.localPosition.y;

        entity.transform.localPosition = pos;

        ResetRootMotion();
    }
}
