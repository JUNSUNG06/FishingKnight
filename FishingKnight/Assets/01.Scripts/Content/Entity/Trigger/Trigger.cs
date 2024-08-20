using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : Entity
{
    private void OnTriggerEnter(Collider other)
    {
        OnTrigger(other);
    }

    public abstract void OnTrigger(Collider other);
}
