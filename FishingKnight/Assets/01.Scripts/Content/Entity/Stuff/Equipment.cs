using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour, IHold
{
    [SerializeField] private Transform anchor;

    [SerializeField] private SocketType socketType;
    SocketType IHold.SocketType { get => socketType; set => socketType = value; }

    public void Hold(Socket holdSocket)
    {
        transform.SetParent(holdSocket.transform);
        transform.localPosition = -anchor.localPosition;
        transform.localRotation = Quaternion.identity;
    }

    public void Unhold()
    {
        Destroy(gameObject);
    }
}