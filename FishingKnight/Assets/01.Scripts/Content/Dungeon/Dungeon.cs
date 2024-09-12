using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    [SerializeField] private DungeonSO dungeonSO;

    private DungeonBoard currentBoard;
    private int currentBoardIndex;

    private DungeonStateType stateType;
    public DungeonStateType StateType => stateType;
    public Action<DungeonStateType> OnDungeonStateChange;

    private NavMeshSurface navSurface;

    private void Awake()
    {
        navSurface = GetComponent<NavMeshSurface>();
    }

    //test
    private void Start()
    {
        EnterDungeon();
    }

    public void EnterDungeon()
    {
        currentBoardIndex = 0;
        currentBoard = Instantiate(dungeonSO.BoardPrefab, transform);
        currentBoard.Init(this);
        currentBoard.SetBoardSo(dungeonSO.BoardSOList[currentBoardIndex]);

        PawnSlotUIPanel pawnSlotUI = Manager.Instance.UI.MainCanvas.GetPanel<PawnSlotUIPanel>();
        pawnSlotUI.SpawnPawnAction += SpawnQueuePawn;
        pawnSlotUI.OnlyShow();

        navSurface.BuildNavMesh();

        ChangeState(DungeonStateType.Arrangement);
    }

    public void GoNextBoard()
    {
        currentBoardIndex++;
        currentBoard = Instantiate(dungeonSO.BoardPrefab, transform);
        currentBoard.Init(this);
        currentBoard.SetBoardSo(dungeonSO.BoardSOList[currentBoardIndex]);
    }

    public void SpawnQueuePawn(PawnSO info)
    {
        HexGrid useableGrid = currentBoard.PawnQueueGridLayout.GetUseableHexGrid();
        if (useableGrid == null)
            return;

        DungeonPawn pawn = Instantiate(info.Prefab, transform);
        pawn.Init(this);
        useableGrid.Arrangement(pawn);
    }

    public void ChangeState(DungeonStateType stateType)
    {
        this.stateType = stateType;

        OnDungeonStateChange?.Invoke(stateType);
    }

    public void ChangeState(string stateName)
    {
        ChangeState((DungeonStateType)Enum.Parse(typeof(DungeonStateType), stateName));
    }
}
