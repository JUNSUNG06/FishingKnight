using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPawnChangeDungeonStateDecision : DungeonPawnFSMDecision
{
    [SerializeField] private DungeonStateType targetState;
    private DungeonStateType currentType;

    private bool isCompared;

    public override void Satisfy()
    {
        if(!isCompared)
        {
            result = currentType == targetState;
            isCompared = true;
        }
    }

    public override void EnterState()
    {
        base.EnterState();

        dungeonPawn.CurrentDungeon.OnDungeonStateChange += CompareState;
    }

    public override void ExitState()
    {
        base.ExitState();

        dungeonPawn.CurrentDungeon.OnDungeonStateChange -= CompareState;
    }

    private void CompareState(DungeonStateType stateType)
    {
        currentType = stateType;
        isCompared = false;
    }
}
