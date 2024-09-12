using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DungeonPawnFSMDecision : FSMDecision
{
    protected DungeonPawn dungeonPawn;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        dungeonPawn = character as DungeonPawn;
    }
}
