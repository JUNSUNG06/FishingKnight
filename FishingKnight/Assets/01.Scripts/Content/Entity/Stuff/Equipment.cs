using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour, IHold, IEquipment
{
    [SerializeField] private Transform holdAnchor;
    [SerializeField] private Transform equipAnchor;

    [SerializeField] private SocketType socketType;
    SocketType IHold.SocketType { get => socketType; set => socketType = value; }
    public GameObject Body { get { return gameObject; } set { return; } }

    private CharacterHolder holder;

    public void Hold(Socket holdSocket, CharacterHolder holder)
    {
        this.holder = holder;
        transform.SetParent(holdSocket.transform);
        transform.localPosition = holdAnchor.localPosition;
        transform.localRotation = holdAnchor.localRotation;
    }

    public void Unhold()
    {
        Destroy(gameObject);
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