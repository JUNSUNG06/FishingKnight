using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingChair : Chair
{
    [SerializeField] private FishingSpot fishingSpot;

    public override void Interact(Entity performer)
    {
        base.Interact(performer);

        if (interacter == null)
            return;

        CharacterHolder holder = interacter.GetEntityComponent<CharacterHolder>();
        if (holder == null)
            return;

        CharacterFishing fishing = interacter.GetComponent<CharacterFishing>();
        if (fishing == null)
            return;

        if (holder.TryGetHoldingObject((h) =>
        {
            if (h == null)
                return false;

            if (h.Body.TryGetComponent<IEquipment>(out IEquipment equip))
            {
                if (equip.EquipmentType == EquipmentType.FishingRob)
                    return true;
            }
            return false;
        }, out IHold holdingObject) == false)
            return;

        fishing.SetFishingSpot(fishingSpot);
        fishing.SetFishingRob(holdingObject.Body.GetComponent<FishingRob>());

        interacter.Anim.Event.RegistEvent(AnimationEventType.Start, RegistChangeState);
    }

    private void RegistChangeState()
    {
        interacter.Anim.Event.UnregistEvent(AnimationEventType.Start, RegistChangeState);
        interacter.Anim.Event.RegistEvent(AnimationEventType.End, ChangeState);
    }

    private void ChangeState()
    {
        interacter.FSM.SetNextState("FishingStart");

        interacter.Anim.Event.UnregistEvent(AnimationEventType.End, ChangeState);
    }
}
