using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DungeonPawnFSMAction : FSMAction
{
    protected DungeonPawn pawn;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        pawn = character as DungeonPawn;
    }
}
