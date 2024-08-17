using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingEndAction : FSMAction
{
    public override void EnterState()
    {
        base.EnterState();

        character.Anim.Event.RegistEvent(AnimationEventType.End, CheckCatchedItem);
    }

    public override void ExitState()
    {
        base.ExitState();

        character.Anim.Event.UnregistEvent(AnimationEventType.End, CheckCatchedItem);
    }

    private void CheckCatchedItem()
    {
        Item item = character.Fishing.CurrentRob.StuckedItem;

        if (item == null)
            return;

        character.Inventory.AddItem(item);
    }
}
