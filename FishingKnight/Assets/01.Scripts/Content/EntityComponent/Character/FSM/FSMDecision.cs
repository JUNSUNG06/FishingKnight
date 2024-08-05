using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMDecision : FSMObject
{
    public abstract bool IsSatisfy();
}