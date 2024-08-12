using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMDecision : FSMObject
{
    public bool Revert;
    protected bool result;

    public bool IsSatisfy()
    {
        result = false;

        Satisfy();

        if(Revert)
            result = !result;

        return result;
    }

    public abstract void Satisfy();
}