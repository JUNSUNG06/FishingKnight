using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBoard : MonoBehaviour
{
    [SerializeField] private PawnSlotUIPanel pawnSlotUIPanel;

    [Space]
    [SerializeField] private HexGridLayout pawnQueueGridLayout;
    public HexGridLayout PawnQueueGridLayout => pawnQueueGridLayout;

    [SerializeField] private HexGridLayout boardGridLayout;
    public HexGridLayout BoardGridLayout => boardGridLayout;

    private DungeonBoardSO boardSO;

    public void SetBoardSo(DungeonBoardSO boardSO)
    {
        this.boardSO = boardSO;
    }
}