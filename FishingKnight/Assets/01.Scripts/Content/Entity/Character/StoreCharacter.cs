using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCharacter : Character, IInteract
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
}