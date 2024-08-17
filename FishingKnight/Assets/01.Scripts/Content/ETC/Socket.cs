using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    private bool isUse;
    public bool IsUes => isUse;

    [SerializeField] private SocketType type;
    public SocketType Type => type;

    private GameObject socketedObject;
    public GameObject SocketedObject => socketedObject;

    public void Use(GameObject socketedObject)
    {
        isUse = true;
        this.socketedObject = socketedObject;
    }

    public void Unuse()
    {
        isUse = false;

        socketedObject = null;
    }
}