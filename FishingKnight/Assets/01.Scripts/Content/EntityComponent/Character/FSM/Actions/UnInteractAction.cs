using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnInteractAction : FSMAction
{
    [SerializeField] private bool onStart;
    [SerializeField] private bool onEnd;

    private CharacterInteract interact;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        interact = character.GetEntityComponent<CharacterInteract>();
    }

    public override void EnterState()
    {
        base.EnterState();

        if (onStart)
            interact.UnInteract();
    }

    public override void ExitState()
    {
        base.ExitState();

        if(!onStart && onEnd)
            interact.UnInteract();
    }
}
