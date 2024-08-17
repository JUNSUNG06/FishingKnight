using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item, IHold, IEquipment
{
    [SerializeField] private Transform holdAnchor;
    [SerializeField] private Transform equipAnchor;

    [SerializeField] private SocketType socketType;
    SocketType IHold.SocketType { get => socketType; set => socketType = value; }
    public GameObject Body { get { return gameObject; } set { return; } }

    [SerializeField] private EquipmentType equipmentType;
    public EquipmentType EquipmentType { get { return equipmentType; } set { return; } }

    private CharacterHolder holder;

    public void Hold(Socket holdSocket, CharacterHolder holder)
    {
        this.holder = holder;
        transform.SetParent(holdSocket.transform);
        transform.localPosition = holdAnchor.localPosition;
        transform.localRotation = holdAnchor.localRotation;

        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    public void Unhold()
    {
        CharacterInventory inventory = owner.GetEntityComponent<CharacterInventory>();
        if (inventory == null)
            return;

        inventory.AddItem(this);
    }

    void IEquipment.Equipment(Socket equipmentSocket, CharacterHolder holder)
    {
        this.holder = holder;
        transform.SetParent(equipmentSocket.transform);
        transform.localPosition = equipAnchor.localPosition;
        transform.localRotation = equipAnchor.localRotation;
    }

    public void Unequipment()
    {
        Socket socket = holder.GetHoldingObjectSocket(this);
        if(socket != null)
        {
            Hold(socket, holder);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}