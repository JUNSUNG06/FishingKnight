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

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        func = (h) =>
        {
            if (h.Body.TryGetComponent<IEquipment>(out IEquipment equip))
            {
                if (equip.Type == equipType)
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
                    if (character.Holder.TryGetHoldingObject(func, out IHold hold))
                    {
                        if (hold.Body.TryGetComponent<IEquipment>(out IEquipment equip))
                        {

                            character.Holder.Equipment(equip);
                        }
                    }
                }
                break;
            case EquipmentActionType.Unequipment:
                character.Holder.Unequipment();
                break;
        }
    }
}
