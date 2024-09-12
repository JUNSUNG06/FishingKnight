using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPawnTargetInnerDistanceDecision : DungeonPawnFSMDecision
{
    private DungeonPawnBattleComponent battle;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        battle = dungeonPawn.GetEntityComponent<DungeonPawnBattleComponent>();
    }

    public override void Satisfy()
    {
        result = battle.BattleSO.AttackRange >=
            Vector3.Distance(dungeonPawn.transform.position, battle.Target.transform.position);
    }
}
