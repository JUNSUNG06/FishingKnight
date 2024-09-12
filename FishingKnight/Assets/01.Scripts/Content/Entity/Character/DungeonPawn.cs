using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPawn : Character, IDrag, IArrangement
{
    [SerializeField] private PawnSO info;
    public PawnSO Info => info;

    private Dungeon currentDungeon;
    public Dungeon CurrentDungeon => currentDungeon;

    public DungeonPawnType pawnType;

    private CharacterFSM fsm;

    public void Init(Dungeon dungeon)
    {
        SetDungeon(dungeon);

        base.Init();

        fsm = GetEntityComponent<CharacterFSM>();
    }

    public void SetDungeon(Dungeon dungeon)
    {
        currentDungeon = dungeon;
    }

    public void OnStrtDrag()
    {
        
    }

    public void OnEndDrag()
    {
        
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void OnArrangement(HexGrid grid)
    {
        switch (grid.gridType)
        {
            case GridType.Queue:
                fsm.SetNextState("Queue");
                break;
            case GridType.BattleField:
                fsm.SetNextState("Idle");
                break;
        }
    }

    public void OnUnArrangement()
    {
        
    }
}