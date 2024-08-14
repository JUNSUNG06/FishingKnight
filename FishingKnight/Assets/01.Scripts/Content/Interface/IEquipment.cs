using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipment
{
    public GameObject Body { get; set; }
    public EquipmentType Type { get; set; }

    public void Equipment(Socket equipmentSocket, CharacterHolder holder);
    public void Unequipment();
}
