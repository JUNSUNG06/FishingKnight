using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMObject : MonoBehaviour
{
    protected Character character;
    public virtual void Initialize(Character character)
    {
        this.character = character;
    }

    public virtual void EnterState() { }
    public virtual void UpdateState() { }
    public virtual void ExitState() { }
}
