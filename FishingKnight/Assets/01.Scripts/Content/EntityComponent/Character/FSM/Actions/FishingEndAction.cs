using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingEndAction : FSMAction
{
    private EntityAnimation anim;
    private CharacterFishing fishing;
    private CharacterInventory inventory;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        anim = character.GetEntityComponent<EntityAnimation>();
        fishing = character.GetEntityComponent<CharacterFishing>();
        inventory = character.GetEntityComponent<CharacterInventory>();
    }

    public override void EnterState()
    {
        base.EnterState();

        anim.Event.RegistEvent(AnimationEventType.End, CheckCatchedItem);
    }

    public override void ExitState()
    {
        base.ExitState();

        anim.Event.UnregistEvent(AnimationEventType.End, CheckCatchedItem);
    }

    private void CheckCatchedItem()
    {
        Item item = fishing.CurrentRob.StuckedItem;

        if (item == null)
            return;

        inventory.AddItem(item);
    }
}
