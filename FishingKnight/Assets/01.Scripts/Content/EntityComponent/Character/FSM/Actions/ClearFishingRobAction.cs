using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearFishingRobAction : FSMAction
{
    public override void EnterState()
    {
        base.EnterState();

        if (character.Fishing.CurrentRob == null)
            return;
        
        character.Fishing.CurrentRob.ClearNeedle();
    }
}
