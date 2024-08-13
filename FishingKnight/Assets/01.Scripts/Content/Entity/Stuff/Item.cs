using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Stuff
{
    protected Entity owner;

    public void SetOwner(Entity owner)
    {
        this.owner = owner;
    }
}
