using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMObject : MonoBehaviour
{
    protected Character owner;
    public virtual void Initialize(Character owner)
    {
        this.owner = owner;
    }

    public virtual void EnterState() { }
    public virtual void UpdateState() { }
    public virtual void ExitState() { }
}
