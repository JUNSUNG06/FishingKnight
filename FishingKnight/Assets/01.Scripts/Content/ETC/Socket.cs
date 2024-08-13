using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    private bool isUse;
    public bool IsUes => isUse;

    [SerializeField] private SocketType type;
    public SocketType Type => type;

    public void Use()
    {
        isUse = true;
    }

    public void Unuse()
    {
        isUse = false;
    }
}