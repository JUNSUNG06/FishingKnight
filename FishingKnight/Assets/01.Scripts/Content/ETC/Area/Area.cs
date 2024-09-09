using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Area : MonoBehaviour
{
    [SerializeField] private bool isStartArea;

    [Space]
    public UnityEvent<Area> OnEnterAreaEvent;
    public UnityEvent<Area> OnExitAreaEvent;

    private void Start()
    {
        if(isStartArea)
        {
            Manager.Instance.Area.ChangeArea(this);
        }
    }

    public virtual void EnterArea()
    {
        Debug.Log(name);
        OnEnterAreaEvent?.Invoke(this);
    }

    public virtual void ExitArea()
    {
        OnExitAreaEvent?.Invoke(this);
    }
}
