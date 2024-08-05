using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : EntityComponent
{
    new protected Character owner;
    new public Character Owner => owner;

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        this.owner = owner as Character;
    }
}
