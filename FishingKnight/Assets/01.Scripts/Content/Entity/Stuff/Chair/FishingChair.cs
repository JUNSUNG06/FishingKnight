using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingChair : Chair
{
    [SerializeField] private FishingSpot fishingSpot;

    private EntityAnimation performerAnim;
    private CharacterFSM performerFSM;

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

        performerAnim = performer.GetEntityComponent<EntityAnimation>();
        performerFSM = performer.GetEntityComponent<CharacterFSM>();

        performerAnim.Event.RegistEvent(AnimationEventType.Start, RegistChangeState);
    }

    private void RegistChangeState()
    {
        performerAnim.Event.UnregistEvent(AnimationEventType.Start, RegistChangeState);
        performerAnim.Event.RegistEvent(AnimationEventType.End, ChangeState);
    }

    private void ChangeState()
    {
        performerFSM.SetNextState("FishingStart");

        performerAnim.Event.UnregistEvent(AnimationEventType.End, ChangeState);
    }
}
