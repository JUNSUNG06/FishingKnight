using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPawnExistTargetDecision : DungeonPawnFSMDecision
{
    private DungeonPawnBattleComponent battle;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        battle = dungeonPawn.GetEntityComponent<DungeonPawnBattleComponent>();
    }

    public override void Satisfy()
    {
        result = battle.Target != null;
    }
}
