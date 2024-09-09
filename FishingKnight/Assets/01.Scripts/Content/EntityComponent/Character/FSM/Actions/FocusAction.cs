using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusAction : FSMAction
{
    private CharacterInteract interact;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        interact = character.GetEntityComponent<CharacterInteract>();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        interact.Focusing();
    }
}
