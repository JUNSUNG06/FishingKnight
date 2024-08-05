using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMDecision : FSMObject
{
    [SerializeField] private bool revert;
    protected bool result;

    public virtual bool IsSatisfy()
    {
        if (revert)
            return !result;

        return false;
    }
}