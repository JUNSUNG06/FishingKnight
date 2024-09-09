using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stuff : Entity, IFocus, IInteract
{
    public UnityEvent<Stuff> OnStartFocusEvent;
    public UnityEvent<Stuff> OnEndFocusEvent;
    public UnityEvent<Stuff> OnInteractEvent;
    public UnityEvent<Stuff> OnUnInteractEvent;

    public Entity GetEntity()
    {
        return this;
    }

    public virtual void StartFocus(Entity performer)
    {
        OnStartFocusEvent?.Invoke(this);
    }

    public virtual void EndFocus(Entity performer)
    {
        OnEndFocusEvent?.Invoke(this);
    }

    public virtual void Interact(Entity performer)
    {
        OnInteractEvent?.Invoke(this);
    }

    public void UnInteract(Entity performer)
    {
        OnUnInteractEvent?.Invoke(this);
    }
}