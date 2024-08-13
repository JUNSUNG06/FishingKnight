using System.Collections.Generic;
using UnityEngine;

public class CharacterHolder : CharacterComponent
{
    public class SocketHoldPair
    {
        public Socket Socket;
        public IHold HoldObject;

        public SocketHoldPair(Socket socket, IHold holdObject)
        {
            Socket = socket;
            HoldObject = holdObject;
        }
    }

    [SerializeField] private List<Socket> holdSockets;
    [SerializeField] private Socket handSocket;
    private Dictionary<SocketType, List<SocketHoldPair>> socketHoldPairDictionary;

    private IHold equipmentObject;

    [SerializeField] Equipment test;

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        socketHoldPairDictionary = new Dictionary<SocketType, List<SocketHoldPair>>();
        foreach (Socket socket in holdSockets)
        {
            if (socketHoldPairDictionary.ContainsKey(socket.Type) == false)
                socketHoldPairDictionary.Add(socket.Type, new List<SocketHoldPair>());

            socketHoldPairDictionary[socket.Type].Add(new SocketHoldPair(socket, null));
        }

        Hold(test);
    }

    public void Hold(IHold holdObject)
    {
        if (IsHoldingObject(holdObject) == true)
            return;

        SocketHoldPair socketHoldPair = socketHoldPairDictionary[holdObject.SocketType].Find(x => x.HoldObject == null);
        if (socketHoldPair == null)
            return;

        socketHoldPair.HoldObject = holdObject;
        socketHoldPair.Socket.Use();
        holdObject.Hold(socketHoldPair.Socket);
    }
    public void Unhold(IHold holdObject)
    {
        if (IsHoldingObject(holdObject) == false)
            return;

        SocketHoldPair socketHoldPair = socketHoldPairDictionary[holdObject.SocketType].Find(x => x.HoldObject == holdObject);
        if (socketHoldPair == null)
            return;

        socketHoldPair.HoldObject = null;
        socketHoldPair.Socket.Unuse();
        holdObject.Unhold();
    }

    public void Equipment(IHold equipmentObject)
    {
        if (IsHoldingObject(equipmentObject) == false)
            return;

        if (this.equipmentObject != null)
            return;

        this.equipmentObject = equipmentObject;
        handSocket.Use();
    }

    public void Unequipment()
    {
        if (equipmentObject == null)
            return;

        equipmentObject = null;
        handSocket.Unuse();
    }

    public bool IsHoldingObject(IHold holdObject)
    {
        if (socketHoldPairDictionary.ContainsKey(holdObject.SocketType) == false)
            return false;

        return socketHoldPairDictionary[holdObject.SocketType].Find(x => x.HoldObject == holdObject) != null;
    }
}