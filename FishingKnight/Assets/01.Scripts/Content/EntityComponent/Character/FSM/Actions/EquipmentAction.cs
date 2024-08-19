using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentAction : FSMAction
{
    public enum EquipmentActionType
    {
        Equipment,
        Unequipment,
    }
    [SerializeField] private EquipmentActionType actionType;
    [SerializeField] private EquipmentType equipType;

    private Func<IHold, bool> func;

    private CharacterHolder holder;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        holder = character.GetEntityComponent<CharacterHolder>();

        func = (h) =>
        {
            if (h == null)
                return false;

            if (h.Body.TryGetComponent<IEquipment>(out IEquipment equip))
            {
                if (equip.EquipmentType == equipType)
                    return true;
            }
            return false;
        };
    }

    public override void EnterState()
    {
        base.EnterState();

        switch (actionType)
        {
            case EquipmentActionType.Equipment:
                {
                    if (holder.TryGetHoldingObject(func, out IHold hold))
                    {
                        if (hold.Body.TryGetComponent<IEquipment>(out IEquipment equip))
                        {
                            holder.Equipment(equip);
                        }
                    }
                }
                break;
            case EquipmentActionType.Unequipment:
                holder.Unequipment();
                break;
        }
    }
}
