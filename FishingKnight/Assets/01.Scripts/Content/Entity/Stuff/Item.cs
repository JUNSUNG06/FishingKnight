using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Stuff
{
    protected Entity owner;

    [SerializeField] private Item prefab;
    public Item Prefab => prefab;

    [SerializeField] private ItemType itemtype;
    public ItemType Itemtype => itemtype;

    public void SetOwner(Entity owner)
    {
        this.owner = owner;
    }
}
