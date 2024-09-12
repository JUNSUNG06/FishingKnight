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

    [SerializeField] private HexGridLayout monsterBoardGridLayout;
    public HexGridLayout MonsterBoardGridLayout => monsterBoardGridLayout;

    private DungeonBoardSO boardSO;

    private Dungeon ownerDungeon;

    public void Init(Dungeon dungeon)
    {
        ownerDungeon = dungeon;

        pawnQueueGridLayout.LayoutGrid();
        boardGridLayout.LayoutGrid();
        monsterBoardGridLayout.LayoutGrid();
    }

    public void SetBoardSo(DungeonBoardSO boardSO)
    {
        this.boardSO = boardSO;

        foreach(PawnArrangeInfo info in boardSO.MonsterPawnArrangeInfoList)
        {
            SpawnMonster(info);
        }
    }

    private void SpawnMonster(PawnArrangeInfo info)
    {
        DungeonPawn monster = Instantiate(info.pawnSO.Prefab, monsterBoardGridLayout.transform);
        monster.pawnType = DungeonPawnType.Monster;
        monster.Init(ownerDungeon);

        HexGrid grid = monsterBoardGridLayout.GetGridByIndex(new Vector2Int(info.x, info.y));
        grid.Arrangement(monster);
    }
}