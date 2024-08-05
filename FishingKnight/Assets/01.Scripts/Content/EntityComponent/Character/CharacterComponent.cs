using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : EntityComponent
{
    protected Character character;
    public Character Character => character;

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        character = owner as Character;
    }
}
