using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPawnFindTargetAction : DungeonPawnFSMAction
{
    private DungeonPawnBattleComponent battle;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        battle = pawn.GetEntityComponent<DungeonPawnBattleComponent>();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        battle.FindTarget();
    }
}
