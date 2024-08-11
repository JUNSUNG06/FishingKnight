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
    }
}
