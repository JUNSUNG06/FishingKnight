using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    [SerializeField] private DungeonSO dungeonSO;

    private DungeonBoard currentBoard;
    private int currentBoardIndex;

    //test
    private void Start()
    {
        EnterDungeon();
    }

    public void EnterDungeon()
    {
        currentBoardIndex = 0;
        currentBoard = Instantiate(dungeonSO.BoardPrefab, transform);
        currentBoard.Init();
        currentBoard.SetBoardSo(dungeonSO.BoardSOList[currentBoardIndex]);

        PawnSlotUIPanel pawnSlotUI = Manager.Instance.UI.MainCanvas.GetPanel<PawnSlotUIPanel>();
        pawnSlotUI.SpawnPawnAction += SpawnPawn;
        pawnSlotUI.OnlyShow();
    }

    public void GoNextBoard()
    {
        currentBoardIndex++;
        currentBoard = Instantiate(dungeonSO.BoardPrefab, transform);
        currentBoard.SetBoardSo(dungeonSO.BoardSOList[currentBoardIndex]);
    }

    public void SpawnPawn(PawnSO info)
    {
        HexGrid useableGrid = currentBoard.PawnQueueGridLayout.GetUseableHexGrid();
        if (useableGrid == null)
            return;

        Pawn pawn = Instantiate(info.Prefab, transform);
        useableGrid.Arrangement(pawn);
    }
}
