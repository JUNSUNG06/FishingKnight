using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingCharacter : Character, IInteract
{
    [SerializeField] private Chair sitChair;

    protected override void Start()
    {
        base.Start();

        if (sitChair != null)
            sitChair.Interact(this);
    }

    public void Interact(Entity performer)
    {
        GetEntityComponent<CharacterDialogue>().StartDialogue(performer);
    }

    public Entity GetEntity()
    {
        return this;
    }

    public void UnInteract(Entity performer)
    {
        
    }
}