using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Stuff
{
    protected Entity owner;

    [SerializeField] private ItemSO info;
    public ItemSO Info => info;

    public void SetOwner(Entity owner)
    {
        this.owner = owner;
    }

    public override void Interact(Entity performer)
    {
        base.Interact(performer);

        if(performer.TryGetComponent<CharacterInventory>(out CharacterInventory inventory))
        {
            inventory.AddItem(this);
        }
    }
}