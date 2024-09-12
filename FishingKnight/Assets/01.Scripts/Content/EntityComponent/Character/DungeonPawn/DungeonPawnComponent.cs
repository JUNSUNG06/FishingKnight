using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPawnComponent : CharacterComponent
{
    protected DungeonPawn dungeonPawn;
    public DungeonPawn DungeonPawn => dungeonPawn;

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        dungeonPawn = owner as DungeonPawn;
    }
}
