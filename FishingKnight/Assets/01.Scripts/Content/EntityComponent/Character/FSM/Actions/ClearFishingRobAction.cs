using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearFishingRobAction : FSMAction
{
    private CharacterFishing fishing;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        fishing = character.GetEntityComponent<CharacterFishing>();
    }

    public override void EnterState()
    {
        base.EnterState();

        if (fishing.CurrentRob == null)
            return;

        fishing.CurrentRob.ClearNeedle();
    }
}
